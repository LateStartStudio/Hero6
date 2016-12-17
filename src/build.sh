# Build Script

# Paket
if [ -f "$./.paket/paket.exe" ]; the
  mono ./.paket/paket.bootstrapper.exe
  exit_code=$?
  if [ $exit_code -ne 0 ]; then
    exit $exit_code
  fi
fi

mono ./.paket/paket.exe restore
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi

# Run FAKE - Default
mono ./packages/FAKE/tools/FAKE.exe
