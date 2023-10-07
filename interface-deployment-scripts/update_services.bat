echo off
nssm stop DMS_Parser
nssm stop DMS_Watcher
bitsadmin /transfer DMS_Linker_Update "https://github.com/RammasEchor/Chevrolet-BussinesPro/releases/latest/download/deployment.zip" "%cd%\deployment.zip"
setlocal
cd /d %~dp0
Call :UnZipFile "%cd%\temp" "%cd%\deployment.zip"
xcopy /y "%cd%\temp\Chevrolet_DMS_Watcher.exe" "%cd%\Chevrolet_DMS_Watcher.exe"
xcopy /y "%cd%\temp\interface-api-businesspro.exe" "%cd%\interface-api-businesspro.exe"
xcopy /y "%cd%\temp\1_set_env_var.bat" "%cd%\1_set_env_var.bat"
xcopy /y "%cd%\temp\2_set_nssm_in_path.bat" "%cd%\2_set_nssm_in_path.bat"
xcopy /y "%cd%\temp\3_install_services.bat" "%cd%\3_install_services.bat"
xcopy /y "%cd%\temp\4_config_services.bat" "%cd%\4_config_services.bat"
xcopy /y "%cd%\temp\restart_services.bat" "%cd%\restart_services.bat"
xcopy /y "%cd%\temp\stop_services.bat" "%cd%\stop_services.bat"
xcopy /y "%cd%\temp\uninstall_services.bat" "%cd%\uninstall_services.bat"
del "%cd%\temp" /q/s
del "%cd%\deployment.zip" /q
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