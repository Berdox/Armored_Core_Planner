# Activate the virtual environment
$activateScript = ".\.venv\Scripts\Activate.ps1"

if (Test-Path $activateScript) {
    . $activateScript
    Write-Host "Virtual environment activated."
} else {
    Write-Host "Virtual environment activation script not found at $activateScript"
}
