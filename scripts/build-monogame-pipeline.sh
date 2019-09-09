CONFIG=$1

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

if [[ "$OSTYPE" == "cygwin" || "$OSTYPE" == "msys" || "$OSTYPE" == "win32" ]]; then
  dotnet build $(dirname $0)/../src/Hero6.MonoGame.Pipeline.sln -c $CONFIG
else
  msbuild $(dirname $0)/../src/Hero6.MonoGame.Pipeline.sln /t:restore /property:Configuration=$CONFIG
  msbuild $(dirname $0)/../src/Hero6.MonoGame.Pipeline.sln /property:Configuration=$CONFIG
fi
