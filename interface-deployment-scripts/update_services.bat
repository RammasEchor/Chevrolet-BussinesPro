echo off
nssm stop DMS_Parser
nssm stop DMS_Watcher
bitsadmin /transfer DMS_Linker_Update /download /priority normal "https://github.com/RammasEchor/Chevrolet-BussinesPro/blob/main/interface-deployment-scripts/deployment.zip" "C:\Program Files\Interfaz_API_BusinessPro\system_update.zip"
setlocal
cd /d %~dp0
Call :UnZipFile "C:\Program Files\Interfaz_API_BusinessPro\temp" "C:\Program Files\Interfaz_API_BusinessPro\system_update.zip"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\Chevrolet_DMS_Watcher.exe" "C:\Program Files\Interfaz_API_BusinessPro\Chevrolet_DMS_Watcher.exe"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\interface-api-businesspro.exe" "C:\Program Files\Interfaz_API_BusinessPro\interface-api-businesspro.exe"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\config_services.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\config_services.bat"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\install_services.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\install_services.bat"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\restart_services.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\restart_services.bat"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\set_env_var.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\set_env_var.bat"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\set_nssm_in_path.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\set_nssm_in_path.bat"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\stop_services.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\stop_services.bat"
xcopy /y "C:\Program Files\Interfaz_API_BusinessPro\temp\uninstall_services.bat" "C:\Program Files\Interfaz_API_BusinessPro\temp\uninstall_services.bat"
del "C:\Program Files\Interfaz_API_BusinessPro\temp" /q/s
del "C:\Program Files\Interfaz_API_BusinessPro\system_update.zip" /q
nssm start DMS_Parser
nssm start DMS_Watcher
PAUSE

:UnZipFile <ExtractTo> <newzipfile>
set vbs="%temp%\_.vbs"
if exist %vbs% del /f /q %vbs%
>%vbs%  echo Set fso = CreateObject("Scripting.FileSystemObject")
>>%vbs% echo If NOT fso.FolderExists(%1) Then
>>%vbs% echo fso.CreateFolder(%1)
>>%vbs% echo End If
>>%vbs% echo set objShell = CreateObject("Shell.Application")
>>%vbs% echo set FilesInZip=objShell.NameSpace(%2).items
>>%vbs% echo objShell.NameSpace(%1).CopyHere(FilesInZip)
>>%vbs% echo Set fso = Nothing
>>%vbs% echo Set objShell = Nothing
cscript //nologo %vbs%
if exist %vbs% del /f /q %vbs%