echo off
nssm stop DMS_Parser
nssm stop DMS_Watcher
bitsadmin /transfer DMS_Linker_Update /download /priority normal "https://github.com/RammasEchor/DMS_Chevrolet_Deployment/raw/master/DMS_Chevrolet_Deployment.zip" "C:\Program Files\DMS_Linker\DMS_Linker_Update.zip"
setlocal
cd /d %~dp0
Call :UnZipFile "C:\Program Files\DMS_Linker\DMS_Linker_Update" "C:\Program Files\DMS_Linker\DMS_Linker_Update.zip"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\DMS_Parser" "C:\Program Files\DMS_Linker\DMS_Parser"
del "C:\Program Files\DMS_Linker\DMS_Watcher" /q
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\DMS_Watcher" "C:\Program Files\DMS_Linker\DMS_Watcher"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\config_services.bat" "C:\Program Files\DMS_Linker\config_services.bat"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\install_services.bat" "C:\Program Files\DMS_Linker\install_services.bat"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\restart_services.bat" "C:\Program Files\DMS_Linker\restart_services.bat"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\set_env_var.bat" "C:\Program Files\DMS_Linker\set_env_var.bat"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\set_nssm_in_path.bat" "C:\Program Files\DMS_Linker\set_nssm_in_path.bat"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\stop_services.bat" "C:\Program Files\DMS_Linker\stop_services.bat"
xcopy /y "C:\Program Files\DMS_Linker\DMS_Linker_Update\DMS_Linker\uninstall_services.bat" "C:\Program Files\DMS_Linker\uninstall_services.bat"
del "C:\Program Files\DMS_Linker\DMS_Linker_Update.zip" /q
del "C:\Program Files\DMS_Linker\DMS_Linker_Update" /q/s
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