#! /bin/bash
rm ./deployment.zip
cp /home/rammas/repos/Chevrolet_DMS_Watcher/bin/Debug/net7.0/win-x86/publish/Chevrolet_DMS_Watcher.exe ./
cp /home/rammas/repos/chevrolet-businessPro/interface-api-businesspro/bin/Debug/net7.0/win-x86/publish/interface-api-businesspro.exe ./
zip -9 -y -r deployment.zip Chevrolet_DMS_Watcher.exe interface-api-businesspro.exe *.bat
rm ./Chevrolet_DMS_Watcher.exe
rm ./interface-api-businesspro.exe
cp deployment.zip ~/VirtualBox\ VMs/Win10/Shared\ Folder/