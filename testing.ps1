param(
    [string]$LogPath = (Join-Path $PSScriptRoot "TestLogs")
)

# ========== Logging Setup ==========
if (-not (Test-Path $LogPath)) { New-Item -ItemType Directory -Path $LogPath | Out-Null }
$LogFile = Join-Path $LogPath ("TestRun_{0}.log" -f (Get-Date -Format "yyyyMMdd_HHmmss"))

function Write-Log {
    param(
        [Parameter(ValueFromPipeline)][string]$Message,
        [ValidateSet("Info","Warning","Error","Success","Header","Highlight")]
        [string]$Level = "Info",
        [switch]$NoConsole   # Write to log file only, skip console output (e.g. verbose raw output)
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
    param([Parameter(ValueFromPipeline)]$InputObject, [string]$Level = "Info")
    begin { $items = @() }
    process { $items += $InputObject }
    end { $items | Format-Table -AutoSize | Out-String | Write-Log -Level $Level }
}

Write-Log "Log file: $LogFile" -Level Header

# Automatically find csproj file
$csprojPath = Get-ChildItem -Filter *.csproj -Recurse | Select-Object -First 1
if (-not $csprojPath) {
    # Changed Write-Error to Write-Log for consistent logging
    Write-Log "Error: Could not find .csproj file!" -Level Error
    exit 1
}

# Read and parse XML
[xml]$csprojXml = Get-Content $csprojPath.FullName

# Extract target frameworks
$pg = $csprojXml.Project.PropertyGroup
$frameworks = @($pg.TargetFramework) + @($pg.TargetFrameworks -split ';' | ForEach-Object { $_.Trim() }) |
    Where-Object { $_ } | Select-Object -Unique

Write-Log "Detected target frameworks:" -Level Success
$frameworks | ForEach-Object { Write-Log " - $_" }

function Parse-TestBlock {
    param($Block)
    $ns    = if ($Block -match "Namespace:\s*(.+)") { $Matches[1].Trim() } else { "" }
    $class = if ($Block -match "Class:\s*(.+)")     { $Matches[1].Trim() } else { "" }
    $status = if ($Block -match "Error:")      { "Error" }
              elseif ($Block -match "Correct")   { "Passed" }
              elseif ($Block -match "Incorrect") { "Failed" }
              else                                { "Unknown" }

    # For tests under the Error namespace, the expected behavior IS for an error to occur.
    # - If the block reports "Error", that's the expected outcome -> map to Passed.
    # - If the block reports "Correct" (i.e. no error occurred, normal successful return),
    #   that means the expected error did NOT happen -> this is actually a failure -> map to Failed.
    if ($ns -like "*SeanOne.Alchemy.Test.Cases.Error*") {
        if ($status -eq "Error") {
            $status = "Passed"
        }
        elseif ($status -eq "Passed") {
            $status = "Failed"
        }
    }

    [PSCustomObject]@{ Namespace = $ns; Class = $class; Status = $status; Block = $Block }
}

# Store all results per framework
$allFrameworkResults = @{}

# Removed Push-Location "." and Pop-Location (no effect)

foreach ($fw in $frameworks) {
    Write-Log "`n==================== Testing $fw ====================" -Level Header

    $rawOutput   = dotnet run --framework $fw --no-build 2>&1 | Out-String
    $exitCode    = $LASTEXITCODE   # Capture immediately

    # Check if dotnet run failed
    if ($exitCode -ne 0) {
        Write-Log "dotnet run exited with code $exitCode for framework $fw. Skipping this framework." -Level Error
        # Log raw output anyway (already written later, but we can write it now)
        $cleanOutput = $rawOutput -replace '\x1B\[[0-9;]*[a-zA-Z]', ''
        Write-Log "----- Raw output for $fw (error) -----`r`n$cleanOutput" -NoConsole
        # Record empty results to keep summary consistent
        $allFrameworkResults[$fw] = @{
            Total = 0; Correct = 0; Incorrect = 0; Error = 0; Details = @()
        }
        continue
    }

    $cleanOutput = $rawOutput -replace '\x1B\[[0-9;]*[a-zA-Z]', ''   # Remove ANSI escape codes

    # Raw output goes to the log file only
    Write-Log "----- Raw output for $fw -----`r`n$cleanOutput" -NoConsole

    # Split by blank lines to get per-test blocks
    $blocks = $cleanOutput -split "`r?`n`r?`n" | Where-Object { $_ -match "Namespace:" -and $_ -match "Class:" }

    if ($blocks) {
        $testResults = $blocks | ForEach-Object { Parse-TestBlock $_ }
        $total     = $testResults.Count
        $correct   = ($testResults | Where-Object Status -eq "Passed").Count
        $incorrect = ($testResults | Where-Object Status -eq "Failed").Count
        $errorCnt  = ($testResults | Where-Object Status -eq "Error").Count
    } else {
        # Fallback to regex on the summary line if block parsing fails
        Write-Log "Warning: Could not parse test blocks, falling back to summary line." -Level Warning
        $match = [regex]::Match($cleanOutput, "Test count:\s*(\d+),\s*Correct:\s*(\d+),\s*Incorrect:\s*(\d+),\s*Error:\s*(\d+)")
        if (-not $match.Success) {
            Write-Log "Error: Unable to parse test results for $fw." -Level Error
            continue
        }
        $total, $correct, $incorrect, $errorCnt = $match.Groups[1..4].Value | ForEach-Object { [int]$_ }
        $testResults = @()   # No detailed info available
    }

    $allFrameworkResults[$fw] = @{
        Total = $total; Correct = $correct; Incorrect = $incorrect; Error = $errorCnt; Details = $testResults
    }
}

# ========== Summary Report ==========
Write-Log "`n========== Cross-framework Test Summary ==========" -Level Success

$summary = foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $r = $allFrameworkResults[$fw]
    [PSCustomObject]@{
        Framework = $fw
        Total     = $r.Total
        Passed    = $r.Correct
        Failed    = $r.Incorrect
        Error     = $r.Error
        PassRate  = if ($r.Total -gt 0) { [math]::Round(($r.Correct / $r.Total) * 100, 2) } else { 0 }
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

# Specifically highlight tests from the 'Error' namespace (whether they are errors or not)
$errorNamespaceTests = foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $allFrameworkResults[$fw].Details | Where-Object { $_.Namespace -like "*SeanOne.Alchemy.Test.Cases.Error*" } |
        ForEach-Object { [PSCustomObject]@{ Framework = $fw; Namespace = $_.Namespace; Class = $_.Class; Status = $_.Status } }
}
if ($errorNamespaceTests) {
    Write-Log "`nTests under 'SeanOne.Alchemy.Test.Cases.Error' namespace:" -Level Highlight
    $errorNamespaceTests | Write-LogTable -Level Highlight
} else {
    Write-Log "`nNo tests found under the 'Error' namespace."
}

Write-Log "`nTest run complete. Log saved to: $LogFile" -Level Success
