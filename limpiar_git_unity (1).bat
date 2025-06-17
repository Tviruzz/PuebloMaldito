@echo off
REM Limpia un repositorio Unity aplicando correctamente el .gitignore
REM Asegúrate de tener un .gitignore correctamente configurado antes de correr esto

echo Eliminando archivos en caché del índice de Git...
git rm -r --cached .

echo Volviendo a agregar solo los archivos válidos según el .gitignore...
git add .

echo Creando commit de limpieza...
git commit -m "🔥 Limpieza final: .gitignore aplicado correctamente"

echo Enviando cambios forzados al repositorio remoto...
git push -u origin main --force

echo.
echo --- Proceso completado ---
pause
