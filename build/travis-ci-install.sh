#!/bin/bash
set -ev

sudo sh -c "echo 'deb http://download.opensuse.org/repositories/home:/tpokorra:/mono/xUbuntu_12.04/ /' >> /etc/apt/sources.list.d/mono-opt.list"

curl http://download.opensuse.org/repositories/home:/tpokorra:/mono/xUbuntu_12.04/Release.key | sudo apt-key add -

sudo apt-get update
sudo apt-get install mono-opt

sudo /opt/mono/bin/mozroots --import --machine --sync
yes | sudo /opt/mono/bin/certmgr -ssl https://go.microsoft.com
yes | sudo /opt/mono/bin/certmgr -ssl https://nugetgallery.blob.core.windows.net
yes | sudo /opt/mono/bin/certmgr -ssl https://nuget.org

curl -L https://nuget.org/nuget.exe > build/nuget.exe

mono build/nuget.exe restore
