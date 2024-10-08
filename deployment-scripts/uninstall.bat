set currentDir=%~dp0%
call %currentDir%service_names.bat
%currentDir%nssm-2.24\win32\nssm.exe remove %dispatch% confirm
%currentDir%nssm-2.24\win32\nssm.exe remove %api% confirm
PAUSE