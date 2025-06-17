@echo off
echo Limpiando archivos rastreados ignorados en Git (Unity)...

:: Paso 1: Eliminar archivos rastreados ignorados
git rm -r --cached .

:: Paso 2: Agregar archivos válidos según .gitignore
git add .

:: Paso 3: Commit de limpieza
git commit -m "Limpieza final automática: eliminación de archivos ignorados (Library, Temp, etc.)"

:: Paso 4: Push forzado
git push -u origin main --force

echo.
echo ✅ Limpieza completada y push forzado exitoso (si no hubo errores).
pause
