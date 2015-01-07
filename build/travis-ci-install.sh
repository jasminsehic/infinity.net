#!/bin/bash
set -ev

sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
sudo sh -c "echo 'deb http://download.mono-project.com/repo/debian wheezy main' >> /etc/apt/sources.list.d/mono-xamarin.list"
sudo sh -c "echo 'deb http://download.mono-project.com/repo/debian wheezy-libtiff-compat main' >> /etc/apt/sources.list.d/mono-xamarin.list"

sudo apt-get update
sudo apt-get install mono-devel referenceassemblies-pcl

sudo mozroots --import --machine --sync
yes | sudo certmgr -ssl https://go.microsoft.com
yes | sudo certmgr -ssl https://nugetgallery.blob.core.windows.net
yes | sudo certmgr -ssl https://nuget.org

curl -L https://nuget.org/nuget.exe > build/nuget.exe

mono build/nuget.exe restore
