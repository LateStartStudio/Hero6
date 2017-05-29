# MonoGame
(new-object net.webclient).DownloadFile('http://www.monogame.net/releases/v3.5.1/MonoGameSetup.exe', 'C:\MonoGameSetup.exe')
Invoke-Command -ScriptBlock {C:\MonoGameSetup.exe /S /v/qn}

# Advanced Installer
(new-object net.webclient).DownloadFile('http://www.advancedinstaller.com/downloads/advinst.msi', 'C:\advinst.msi')
Invoke-Command -ScriptBlock {msiexec.exe /i C:\advinst.msi /qn}

# Paket
cd src
Start-Process -FilePath ".paket\paket.bootstrapper.exe" -NoNewWindow -Wait
Start-Process -FilePath ".paket\paket.exe" -ArgumentList "restore" -NoNewWindow -Wait
cd ..
