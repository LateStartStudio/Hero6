CONFIG=$1

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

if [[ "$OSTYPE" == "cygwin" || "$OSTYPE" == "msys" || "$OSTYPE" == "win32" ]]; then
  dotnet restore $(dirname $0)/../src/Hero6.MonoGamePipeline.sln -c $CONFIG
else
  msbuild $(dirname $0)/../src/Hero6.MonoGamePipeline.sln /t:restore /property:Configuration=$CONFIG
fi
