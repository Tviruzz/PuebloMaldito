# Navega al directorio del proyecto (ajusta si lo necesitas)
Set-Location -Path "$PSScriptRoot"

# Limpia archivos ignorados por .gitignore (como Library, Temp, etc.)
git clean -fdX

Write-Host "Archivos y carpetas ignoradas por Git han sido eliminados." -ForegroundColor Green
