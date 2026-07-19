# Automatically find csproj file
$csprojPath = Get-ChildItem -Filter *.csproj -Recurse | Select-Object -First 1
if (-not $csprojPath) {
    Write-Error "Error: Could not find .csproj file!"
    exit 1
}

# Read and parse XML
[xml]$csprojXml = Get-Content $csprojPath.FullName

# Extract target frameworks
$frameworks = @()
if ($csprojXml.Project.PropertyGroup.TargetFramework) {
    $frameworks += $csprojXml.Project.PropertyGroup.TargetFramework
}
if ($csprojXml.Project.PropertyGroup.TargetFrameworks) {
    $frameworks += $csprojXml.Project.PropertyGroup.TargetFrameworks.Split(';') | ForEach-Object { $_.Trim() }
}
$frameworks = $frameworks | Where-Object { $_ } | Select-Object -Unique

Write-Host "Detected target frameworks:" -ForegroundColor Green
$frameworks | ForEach-Object { Write-Host " - $_" -ForegroundColor Gray }

# Store all results per framework
$allFrameworkResults = @{}

Push-Location "."

foreach ($fw in $frameworks) {
    Write-Host "`n==================== Testing $fw ====================" -ForegroundColor Cyan

    # Run tests and capture output (keep raw for debugging)
    $rawOutput = dotnet run --framework $fw --no-build 2>&1 | Out-String
    $cleanOutput = $rawOutput -replace '\x1B\[[0-9;]*[a-zA-Z]', ''   # Remove ANSI escape codes

    # Split by blank lines to get per-test blocks
    $blocks = $cleanOutput -split "`r?`n`r?`n" | Where-Object { $_ -match "Namespace:" -and $_ -match "Class:" }

    $testResults = @()
    if ($blocks) {
        # Parse each test block
        foreach ($block in $blocks) {
            $ns = if ($block -match "Namespace:\s*(.+)") { $Matches[1].Trim() } else { "" }
            $class = if ($block -match "Class:\s*(.+)") { $Matches[1].Trim() } else { "" }

            $isError = $block -match "Error:"
            $isCorrect = $block -match "Correct"
            $isIncorrect = $block -match "Incorrect"

            if ($isError) {
                $status = "Error"
            } elseif ($isCorrect) {
                $status = "Passed"
            } elseif ($isIncorrect) {
                $status = "Failed"
            } else {
                $status = "Unknown"
            }

            $testResults += [PSCustomObject]@{
                Namespace = $ns
                Class     = $class
                Status    = $status
                Block     = $block   # Keep for debugging if needed
            }
        }

        $total = $testResults.Count
        $correct = ($testResults | Where-Object { $_.Status -eq "Passed" }).Count
        $incorrect = ($testResults | Where-Object { $_.Status -eq "Failed" }).Count
        $error = ($testResults | Where-Object { $_.Status -eq "Error" }).Count
    } else {
        # Fallback to regex on the summary line if block parsing fails
        Write-Host "Warning: Could not parse test blocks, falling back to summary line." -ForegroundColor Yellow
        $pattern = "Test count:\s*(\d+),\s*Correct:\s*(\d+),\s*Incorrect:\s*(\d+),\s*Error:\s*(\d+)"
        $match = [regex]::Match($cleanOutput, $pattern)
        if ($match.Success) {
            $total = [int]$match.Groups[1].Value
            $correct = [int]$match.Groups[2].Value
            $incorrect = [int]$match.Groups[3].Value
            $error = [int]$match.Groups[4].Value
            $testResults = @()   # No detailed info available
        } else {
            Write-Host "Error: Unable to parse test results for $fw." -ForegroundColor Red
            continue
        }
    }

    $allFrameworkResults[$fw] = @{
        Total     = $total
        Correct   = $correct
        Incorrect = $incorrect
        Error     = $error
        Details   = $testResults
    }
}

Pop-Location

# ========== Summary Report ==========
Write-Host "`n========== Cross-framework Test Summary ==========" -ForegroundColor Green

$summary = @()
foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $r = $allFrameworkResults[$fw]
    $summary += [PSCustomObject]@{
        Framework = $fw
        Total     = $r.Total
        Passed    = $r.Correct
        Failed    = $r.Incorrect
        Error     = $r.Error
        PassRate  = if ($r.Total -gt 0) { [math]::Round(($r.Correct / $r.Total) * 100, 2) } else { 0 }
    }
}
$summary | Format-Table -AutoSize

# Show failed/error details per framework
$hasIssues = $false
foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $details = $allFrameworkResults[$fw].Details
    $issues = $details | Where-Object { $_.Status -eq "Failed" -or $_.Status -eq "Error" }
    if ($issues) {
        $hasIssues = $true
        Write-Host "`nFramework $fw - Failed/Error tests:" -ForegroundColor Yellow
        $issues | Select-Object Namespace, Class, Status | Format-Table -AutoSize
    }
}

if (-not $hasIssues) {
    Write-Host "`nAll tests passed!" -ForegroundColor Green
}

# Specifically highlight tests from the 'Error' namespace (whether they are errors or not)
$errorNamespaceTests = @()
foreach ($fw in $allFrameworkResults.Keys | Sort-Object) {
    $details = $allFrameworkResults[$fw].Details
    $errorNamespaceTests += $details | Where-Object { $_.Namespace -like "*SeanOne.Alchemy.Test.Cases.Error*" } | ForEach-Object {
        [PSCustomObject]@{
            Framework = $fw
            Namespace = $_.Namespace
            Class     = $_.Class
            Status    = $_.Status
        }
    }
}
if ($errorNamespaceTests) {
    Write-Host "`nTests under 'SeanOne.Alchemy.Test.Cases.Error' namespace:" -ForegroundColor Magenta
    $errorNamespaceTests | Format-Table -AutoSize
} else {
    Write-Host "`nNo tests found under the 'Error' namespace." -ForegroundColor Gray
}
