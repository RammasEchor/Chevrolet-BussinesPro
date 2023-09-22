#! /bin/bash

cp /home/rammas/repos/Chevrolet_DMS_Watcher/bin/Debug/net7.0/win-x64/publish/Chevrolet_DMS_Watcher.exe ./
cp /home/rammas/repos/chevrolet-businessPro/interface-api-businesspro/bin/Debug/net7.0/win-x64/publish/interface-api-businesspro.exe ./
zip -9 -y -r deployment.zip Chevrolet_DMS_Watcher.exe interface-api-businesspro.exe *.bat
rm ./Chevrolet_DMS_Watcher.exe
rm ./interface-api-businesspro.exe