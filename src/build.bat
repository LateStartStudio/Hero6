REM Build Script
@ECHO off
SETLOCAL

CLS

REM Paket
IF NOT EXIST ".paket\paket.exe" (
  .paket\paket.bootstrapper.exe
  IF errorlevel 1 (
    EXIT /b %errorlevel%
  )
)

.paket\paket.exe restore
IF errorlevel 1 (
  EXIT /b %errorlevel%
)

REM Run FAKE - Default
packages\FAKE\tools\FAKE.exe
