set currentDir=%~dp0%
call %currentDir%service_names.bat
%currentDir%nssm-2.24\win32\nssm.exe set %dispatch% AppEnvironmentExtra API_INTERFACE_DIR="%currentDir%toBusinessPro" BUSINESS_PRO_BASE_URL="http://192.168.17.46:2024/"
%currentDir%nssm-2.24\win32\nssm.exe set %api% AppEnvironmentExtra 
PAUSE