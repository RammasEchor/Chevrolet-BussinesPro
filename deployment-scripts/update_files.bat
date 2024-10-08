set currentDir=%~dp0%
call %currentDir%service_names.bat
call %currentDir%stop.bat
mkdir "%currentDir%temp"
xcopy /y "%currentDir%service_names.bat" "%currentDir%temp\service_names.bat"
xcopy /y "%currentDir%env_variables.bat" "%currentDir%temp\env_variables.bat"
xcopy /y "%currentDir%appsettings.json" "%currentDir%temp\appsettings.json"
powershell -command "Expand-Archive -Path '%currentDir%deployment.zip' -DestinationPath '%currentDir%' -Force"
xcopy /y "%currentDir%temp\service_names.bat" "%currentDir%service_names.bat"
xcopy /y "%currentDir%temp\env_variables.bat" "%currentDir%env_variables.bat"
xcopy /y "%currentDir%temp\appsettings.json" "%currentDir%appsettings.json"
call %currentDir%restart.bat
PAUSE