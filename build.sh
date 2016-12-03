# Build Script

# Paket
mono .paket/paket.bootstrapper.exe
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi

mono .paket/paket.exe restore
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi

# Compile Build Configs, Debug and Release
xbuild /p:Configuration=Debug ./Hero6.Linux.sln
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi

xbuild /p:Configuration=Release ./Hero6.Linux.sln
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi

# Run Unit Tests
mono ./packages/NUnit.ConsoleRunner/tools/nunit3-console.exe ./src/Collections.Tests/bin/Debug/Collections.Tests.dll
mono ./packages/NUnit.ConsoleRunner/tools/nunit3-console.exe ./src/Collections.Tests/bin/Release/Collections.Tests.dll
mono ./packages/NUnit.ConsoleRunner/tools/nunit3-console.exe ./src/Search.Tests/bin/Debug/Search.Tests.dll
mono ./packages/NUnit.ConsoleRunner/tools/nunit3-console.exe ./src/Search.Tests/bin/Release/Search.Tests.dll
if [ "${TRAVIS_PULL_REQUEST}" = "true" ]; then
  mono ./packages/NUnit.ConsoleRunner/tools/nunit3-console.exe ./src/Hero6.DesktopGL.Tests/bin/Debug/Hero6.Tests.dll
  mono ./packages/NUnit.ConsoleRunner/tools/nunit3-console.exe ./src/Hero6.DesktopGL.Tests/bin/Release/Hero6.Tests.dll
fi
