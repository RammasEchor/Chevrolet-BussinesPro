#! /bin/bash
rm ./deployment.zip
cp /home/rammas/repos/chevrolet-businessPro/api-businesspro/bin/Release/net8.0/win-x86/publish/api-businesspro.exe ./
cp /home/rammas/repos/chevrolet-businessPro/api-businesspro/database.sql ./
zip -9 -y -r deployment.zip api-businesspro.exe database.sql
rm ./api-businesspro.exe
rm ./database.sql
cp deployment.zip ~/VirtualBox\ VMs/Win10/Shared\ Folder/