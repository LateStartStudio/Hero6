REM Build Script
@ECHO off
SETLOCAL

CLS

REM Paket
.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

REM Run FAKE - Default
packages\FAKE\tools\FAKE.exe
