param(
    [string]$LogPath = (Join-Path $PSScriptRoot "TestLogs")
)

# ========== Logging Setup ==========
if (-not (Test-Path $LogPath)) {
    New-Item -ItemType Directory -Path $LogPath | Out-Null
}
$LogFile = Join-Path $LogPath ("TestRun_{0}.log" -f (Get-Date -Format "yyyyMMdd_HHmmss"))

function Write-Log {
    param(
        [Parameter(ValueFromPipeline)][string]$Message,
        [ValidateSet("Info", "Warning", "Error", "Success", "Header", "Highlight")]
        [string]$Level = "Info",
        [switch]$NoConsole   # Write to log file only, skip console output
    )
    process {
        $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
        Add-Content -Path $LogFile -Value "[$timestamp] [$Level] $Message"

        if (-not $NoConsole) {
            $color = switch ($Level) {
                "Warning"   { "Yellow" }
                "Error"     { "Red" }
                "Success"   { "Green" }
                "Header"    { "Cyan" }
                "Highlight" { "Magenta" }
                default     { "Gray" }
            }
            Write-Host $Message -ForegroundColor $color
        }
    }
}

# Unified table output: prints to console + writes to log file
function Write-LogTable {
    param(
        [Parameter(ValueFromPipeline)]$InputObject,
        [string]$Level = "Info"
    )
    begin { $items = @() }
    process { $items += $InputObject }
    end {
        $items | Format-Table -AutoSize | Out-String | Write-Log -Level $Level
    }
}

Write-Log "Log file: $LogFile" -Level Header

# ========== Locate project file ==========
$csprojFile = Get-ChildItem -Filter *.csproj -Recurse | Select-Object -First 1
if (-not $csprojFile) {
    Write-Log "Error: Could not find any .csproj file in the current directory tree." -Level Error
    exit 1
}

# ========== Parse target frameworks ==========
[xml]$csprojXml = Get-Content $csprojFile.FullName

# Collect all PropertyGroup elements, merge their TargetFramework/TargetFrameworks
$allFrameworks = @()
foreach ($pg in $csprojXml.Project.PropertyGroup) {
    if ($pg.TargetFramework) {
        $allFrameworks += $pg.TargetFramework
    }
    if ($pg.TargetFrameworks) {
        $allFrameworks += $pg.TargetFrameworks -split ';' | ForEach-Object { $_.Trim() }
    }
}
$frameworks = $allFrameworks | Where-Object { $_ } | Select-Object -Unique

Write-Log "Detected target frameworks:" -Level Success
$frameworks | ForEach-Object { Write-Log " - $_" }

# ========== Test result parsing ==========
function Parse-TestBlock {
    param($Block)
    $ns    = if ($Block -match "Namespace:\s*(.+)")    { $Matches[1].Trim() } else { "" }
    $class = if ($Block -match "Class:\s*(.+)")        { $Matches[1].Trim() } else { "" }
    $status = if ($Block -match "Error:")      { "Error" }
              elseif ($Block -match "Correct")   { "Passed" }
              elseif ($Block -match "Incorrect") { "Failed" }
              else                                { "Unknown" }

    # For tests under the Error namespace, the expected behavior IS an error.
    # If the block reports "Error", that is expected -> Passed.
    # If it reports "Correct" (no error), that is a failure -> Failed.
    if ($ns -like "*SeanOne.Alchemy.Test.Cases.Error*") {
        if ($status -eq "Error") {
            $status = "Passed"
        }
        elseif ($status -eq "Passed") {
            $status = "Failed"
        }
    }

    [PSCustomObject]@{
        Namespace = $ns
        Class     = $class
        Status    = $status
        Block     = $Block
    }
}

# ========== Run tests per framework ==========
$allFrameworkResults = @{}

foreach ($fw in $frameworks) {
    Write-Log "`n==================== Testing $fw ====================" -Level Header

    $rawOutput = dotnet run --framework $fw --no-build 2>&1 | Out-String
    $exitCode  = $LASTEXITCODE

    if ($exitCode -ne 0) {
        Write-Log "dotnet run exited with code $exitCode for framework $fw. Skipping this framework." -Level Error
        $cleanOutput = $rawOutput -replace '\x1B\[[0-9;]*[a-zA-Z]', ''
        Write-Log "----- Raw output for $fw (error) -----`r`n$cleanOutput" -NoConsole
        $allFrameworkResults[$fw] = @{
            Total    = 0
            Passed   = 0
            Failed   = 0
            Error    = 0
            Details  = @()
        }
        continue
    }

    $cleanOutput = $rawOutput -replace '\x1B\[[0-9;]*[a-zA-Z]', ''   # Remove ANSI escape codes

    # Log raw output (only to file)
    Write-Log "----- Raw output for $fw -----`r`n$cleanOutput" -NoConsole

    # Split by blank lines to isolate test blocks
    $blocks = $cleanOutput -split "`r?`n`r?`n" | Where-Object { $_ -match "Namespace:" -and $_ -match "Class:" }

    if ($blocks) {
        $testResults = $blocks | ForEach-Object { Parse-TestBlock $_ }
        $total   = $testResults.Count
        $passed  = ($testResults | Where-Object Status -eq "Passed").Count
        $failed  = ($testResults | Where-Object Status -eq "Failed").Count
        $error   = ($testResults | Where-Object Status -eq "Error").Count
    } else {
        # Fallback: try to parse summary line if block parsing failed
        Write-Log "Warning: Could not parse test blocks, falling back to summary line." -Level Warning
        $match = [regex]::Match($cleanOutput, "Test count:\s*(\d+),\s*Correct:\s*(\d+),\s*Incorrect:\s*(\d+),\s*Error:\s*(\d+)")
        if (-not $match.Success) {
            Write-Log "Error: Unable to parse test results for $fw." -Level Error
            continue
        }
        $total, $passed, $failed, $error = $match.Groups[1..4].Value | ForEach-Object { [int]$_ }
        $testResults = @()   # No detailed info
    }

    $allFrameworkResults[$fw] = @{
        Total   = $total
        Passed  = $passed
        Failed  = $failed
        Error   = $error
        Details = $testResults
    }
}

# ========== Cross-framework summary ==========
Write-Log "`n========== Cross-framework Test Summary ==========" -Level Success

$summary = foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $r = $allFrameworkResults[$fw]
    [PSCustomObject]@{
        Framework = $fw
        Total     = $r.Total
        Passed    = $r.Passed
        Failed    = $r.Failed
        Error     = $r.Error
        PassRate  = if ($r.Total -gt 0) { [math]::Round(($r.Passed / $r.Total) * 100, 2) } else { 0 }
    }
}
$summary | Write-LogTable

# Show failed/error details per framework
$hasIssues = $false
foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $issues = $allFrameworkResults[$fw].Details | Where-Object { $_.Status -in "Failed", "Error" }
    if ($issues) {
        $hasIssues = $true
        Write-Log "`nFramework $fw - Failed/Error tests:" -Level Warning
        $issues | Select-Object Namespace, Class, Status | Write-LogTable -Level Warning
    }
}
if (-not $hasIssues) {
    Write-Log "`nAll tests passed!" -Level Success
}

# Specifically highlight tests from the 'Error' namespace (regardless of outcome)
$errorNamespaceTests = foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $allFrameworkResults[$fw].Details | Where-Object { $_.Namespace -like "*SeanOne.Alchemy.Test.Cases.Error*" } |
        ForEach-Object {
            [PSCustomObject]@{
                Framework = $fw
                Namespace = $_.Namespace
                Class     = $_.Class
                Status    = $_.Status
            }
        }
}
if ($errorNamespaceTests) {
    Write-Log "`nTests under 'SeanOne.Alchemy.Test.Cases.Error' namespace:" -Level Highlight
    $errorNamespaceTests | Write-LogTable -Level Highlight
} else {
    Write-Log "`nNo tests found under the 'Error' namespace."
}

Write-Log "`nTest run complete. Log saved to: $LogFile" -Level Success
