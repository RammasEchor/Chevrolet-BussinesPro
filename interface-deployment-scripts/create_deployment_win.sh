#! /bin/bash

cp /home/rammas/repos/Chevrolet_DMS_Watcher/bin/Debug/net7.0/win-x64/publish/Chevrolet_DMS_Watcher.exe ./
cp /home/rammas/repos/chevrolet-businessPro/interface-api-businesspro/bin/Debug/net7.0/win-x64/publish/interface-api-businesspro.exe ./
zip deployment.zip Chevrolet_DMS_Watcher.exe interface-api-businesspro.exe
rm ./Chevrolet_DMS_Watcher.exe
rm ./interface-api-businesspro.exe