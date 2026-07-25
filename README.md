# Test Project

This repository is used exclusively for testing and verifying another project.  
No production code is included.

---

## `testing.ps1` – Cross-framework test runner

This script automatically discovers the `.csproj` file, detects all target frameworks defined in it, runs the tests for each framework, and generates a consolidated summary with pass/fail/error counts.

### Prerequisites

- .NET SDK (compatible with the project's target frameworks)
- PowerShell 5.1 or later (Windows) / PowerShell 7+ (cross-platform)

### Usage

```powershell
.\testing.ps1
```

By default, logs are saved to a `TestLogs` folder under the script's directory, with a filename like `TestRun_20260725_143022.log`.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `-LogPath` | `string` | `(Join-Path $PSScriptRoot "TestLogs")` | Directory where log files will be stored. |

Example with custom log path:

```powershell
.\testing.ps1 -LogPath "C:\MyLogs"
```

### What the script does

1. Locates the first `.csproj` file in the current directory tree.
2. Reads the `TargetFramework` / `TargetFrameworks` properties.
3. For each framework, runs `dotnet run --framework <fw> --no-build`.
4. Parses the test output (expects blocks containing `Namespace:`, `Class:`, and `Correct`/`Incorrect`/`Error` markers).
5. Treats `Error` status under the `SeanOne.Alchemy.Test.Cases.Error` namespace as **Passed** (expected errors).
6. Generates a summary table showing:
   - Total tests
   - Passed / Failed / Error counts
   - Pass rate
7. Lists all failed or unexpected-error tests per framework.
8. Highlights all tests under the `Error` namespace for quick review.

### Logging

- All console output is also written to the log file.
- Raw test output is saved only to the log file (not shown on console) to keep the screen clean.
- The final summary and any issues are printed to the console with color coding.

### Exit codes

- `0` – script completed successfully (even if some tests failed).
- `1` – critical error (e.g., `.csproj` not found).

---

## Notes

- The script assumes the project has already been **built** (it uses `--no-build`).  
- If `dotnet run` fails for any framework (non-zero exit code), that framework is skipped and recorded as an error in the summary.
- Test output format must follow the conventions expected by the parser (as defined in the associated test project).

---

**For any issues, check the generated log file for detailed raw output.**
