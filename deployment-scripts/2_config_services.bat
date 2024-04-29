%API_INTERFACE_DIR%\nssm-2.24\win32\nssm.exe install Interfaz-Chevrolet-BusinessPro
PAUSE
%API_INTERFACE_DIR%\nssm-2.24\win32\nssm.exe set Interfaz-Chevrolet-BusinessPro AppEnvironmentExtra API_INTERFACE_DIR="%API_INTERFACE_DIR%" BUSINESS_PRO_BASE_URL=%BUSINESS_PRO_BASE_URL%
PAUSE