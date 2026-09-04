# Prompt for the drive letter
$drive = Read-Host "Enter the drive letter containing Buy-Sell-Beater (e.g. F)"

# Remove ":" if the user entered it
$drive = $drive.TrimEnd(':').ToUpper()

# Project root
$projectRoot = "${drive}:\repos\buy-sell-beater"

# Prompt for runtime environment
$envChoice = Read-Host "Select environment: Development or Production"
$envChoice = $envChoice.Trim()

if ($envChoice -eq "Development" -or $envChoice -eq "Production") {
    $launchSettingsPath = Join-Path $projectRoot "BuySellBeater.api\Properties\launchSettings.json"
    $json = Get-Content -Path $launchSettingsPath -Raw | ConvertFrom-Json

    foreach ($profile in $json.profiles.PSObject.Properties) {
        if ($profile.Value.environmentVariables) {
            $profile.Value.environmentVariables.ASPNETCORE_ENVIRONMENT = $envChoice
        }
    }

    $json | ConvertTo-Json -Depth 10 | Set-Content -Path $launchSettingsPath
}
else {
    Write-Host "Invalid environment selection. Please enter 'Development' or 'Production'."
    exit 1
}

# Start API in a new PowerShell window
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$projectRoot\BuySellBeater.api'; dotnet watch"

# Start Client in a new PowerShell window
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$projectRoot\BuySellBeater.Client'; ng serve"