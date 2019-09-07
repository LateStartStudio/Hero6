CONFIG=$1

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

dotnet build $(dirname $0)/../src/Hero6.MonoGamePipeline.sln -c $CONFIG

# if [[ "$OSTYPE" == "cygwin" || "$OSTYPE" == "msys" || "$OSTYPE" == "win32" ]]; then
#   dotnet build $(dirname $0)/../src/Hero6.MonoGamePipeline.sln -c $CONFIG
# else
#   msbuild $(dirname $0)/../src/Hero6.MonoGamePipeline.sln /t:restore /property:Configuration=$CONFIG
#   msbuild $(dirname $0)/../src/Hero6.MonoGamePipeline.sln /property:Configuration=$CONFIG
# fi
