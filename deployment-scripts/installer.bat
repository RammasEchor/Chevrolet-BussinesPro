set currentDir=%~dp0%
call %currentDir%service_names.bat
%currentDir%nssm-2.24\win32\nssm.exe install %dispatch%
%currentDir%nssm-2.24\win32\nssm.exe install %api%
PAUSE