#! /bin/bash
rm ./deployment.zip
cp /home/rammas/repos/chevrolet-businessPro/interface-api-businesspro/bin/Release/net8.0/win-x86/publish/interface-api-businesspro.exe ./
cp /home/rammas/repos/chevrolet-businessPro/api-businesspro/bin/Release/net8.0/win-x86/publish/api-businesspro.exe ./
cp /home/rammas/repos/chevrolet-businessPro/api-businesspro/bin/Release/net8.0/win-x86/publish/appsettings.json ./
cp /home/rammas/repos/chevrolet-businessPro/api-businesspro/database.sql ./
zip -9 -y -r deployment.zip interface-api-businesspro.exe api-businesspro.exe database.sql appsettings.json *.bat 
rm ./interface-api-businesspro.exe
rm ./api-businesspro.exe
rm ./appsettings.json
rm ./database.sql
cp deployment.zip ~/VirtualBox\ VMs/Win10/Shared\ Folder/