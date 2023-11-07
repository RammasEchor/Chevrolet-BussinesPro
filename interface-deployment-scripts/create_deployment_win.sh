#! /bin/bash
rm ./deployment.zip
cp /home/rammas/repos/chevrolet-businessPro/interface-api-businesspro/bin/Release/net7.0/win-x86/publish/interface-api-businesspro.exe ./
mkdir progress-scripts
cp /home/rammas/repos/progress-scripts/progress-scripts/* ./progress-scripts
zip -9 -y -r deployment.zip interface-api-businesspro.exe *.bat progress-scripts/*
rm ./interface-api-businesspro.exe
rm -r ./progress-scripts/
cp deployment.zip ~/VirtualBox\ VMs/Win10/Shared\ Folder/