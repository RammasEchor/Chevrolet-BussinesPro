setlocal
mkdir %API_INTERFACE_DIR%
mkdir "%API_INTERFACE_DIR%\temp"
mkdir "%API_INTERFACE_DIR%\progress-scripts"
cd /d %~dp0
powershell -command "Expand-Archive -Force 'deployment.zip' '%API_INTERFACE_DIR%\temp'"
xcopy /y "%API_INTERFACE_DIR%\temp\interface-api-businesspro.exe" "%API_INTERFACE_DIR%\interface-api-businesspro.exe"
xcopy /y /s "%API_INTERFACE_DIR%\temp\progress-scripts\*" "%API_INTERFACE_DIR%\progress-scripts\*"
xcopy /y "%API_INTERFACE_DIR%\temp\*.bat" "%API_INTERFACE_DIR%\*.bat"
del "%API_INTERFACE_DIR%\temp" /q/s
del "%cd%\deployment.zip" /q
PAUSE