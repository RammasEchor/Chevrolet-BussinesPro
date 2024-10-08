set currentDir=%~dp0%
cmd /V /C "set API_INTERFACE_DIR=%currentDir%toBusinessPro&& BUSINESS_PRO_BASE_URL=http://192.168.17.46:2024/&& %currentDir%interface-api-businesspro.exe"