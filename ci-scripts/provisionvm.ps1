# ---------------------------------------------------
# Script used to provision Windows Server 2012 VMs
# for .NET sample testing.
# Originally referenced here: https://gist.github.com/snallami/5aa9ea2c57836a3b3635
# Modified by Den Delimarsky (dendeli)
# ---------------------------------------------------

Set-ExecutionPolicy Unrestricted

$logFile = "C:\provisionlog.txt"

Function LogWrite
{
   Param ([string]$logString)

   Write-Host $logString
   Add-content $logFile -value $logString
}

# Jenkins plugin will dynamically pass the server name and VM name.
$jenkinsserverurl = $args[0]
$vmname = $args[1]

LogWrite "Bootrstapping provisioning..."
LogWrite "Server URL: $jenkinsserverurl"
LogWrite "VM: $vmname"

# Install Chocolatey, and subsequently - GIT tools
# This will do a silent install and by far one that will cause the least headache.

LogWrite "Installing Chocolatey..."
Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) | Out-Null

LogWrite "Installing Git tools..."
choco install git -params '"/GitAndUnixToolsOnPath"' -y --force | Out-Null

# Set the environment variable to containt the path to Git tools (somehow, this is missed within the current context)
$env:Path = [Environment]::GetEnvironmentVariable('Path',[System.EnvironmentVariableTarget]::Machine) + ";C:\Program Files\Git\cmd"
LogWrite "Git tools installed. Current PATH is:"
LogWrite $env:Path

# Install .NET Core
LogWrite "Installing .NET Core..."
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0-preview2/scripts/obtain/dotnet-install.ps1" -OutFile "./dotnet-install.ps1"
./dotnet-install.ps1 -Version 1.0.0-preview2-003121 -InstallDir "C:\dotnet"
$env:Path += ";C:\dotnet"
LogWrite ".NET Core installed. Current PATH is:"
LogWrite $env:Path

# Download the Zulu ZIP file to a location within the VM
# and extract it. This is our Java runtime.
LogWrite "Downloading Zulu SDK..."
$source = "http://cdn.azul.com/zulu/bin/zulu8.15.0.1-jdk8.0.92-win_x64.zip?jenkins"
mkdir c:\azurecsdir
$destination = "c:\azurecsdir\zuluJDK.zip"
$wc = New-Object System.Net.WebClient
$wc.DownloadFile($source, $destination)

LogWrite "Unzipping Zulu SDK..."
$shell_app=new-object -com shell.application 
$zip_file = $shell_app.namespace($destination) 
mkdir c:\java
$destination = $shell_app.namespace("c:\java") 
$destination.Copyhere($zip_file.items())
LogWrite "Successfully downloaded and extracted Zulu SDK."

# Downloading Jenkins slave JAR
LogWrite "Downloading Jenkins slave JAR..."
$slaveSource = $jenkinsserverurl + "jnlpJars/slave.jar"
$destSource = "c:\java\slave.jar"

LogWrite "Slave source: $slaveSource"
LogWrite "Destination: $destSource"

$wc = New-Object System.Net.WebClient
$wc.DownloadFile($slaveSource, $destSource)

# Run Jenkins slave on the Windows host.
LogWrite "Running Jenkins slave process..."
$java="c:\java\zulu8.15.0.1-jdk8.0.92-win_x64\bin\java.exe"
$jar="-jar"
$jnlpUrl="-jnlpUrl" 
$serverURL=$jenkinsserverurl+"computer/" + $vmname + "/slave-agent.jnlp"
$jnlpCredentialsFlag="-jnlpCredentials"
$credentials="admin:0dc7f5e2d5142967db8179c9faf4cebf"

LogWrite "Will execute this:"
LogWrite $java + " " + $jar + " " + $destSource + " " + $jnlpCredentialsFlag + " " + $credentials + " " + $jnlpUrl + " " + $serverURL

& $java $jar $destSource $jnlpCredentialsFlag $credentials $jnlpUrl $serverURL