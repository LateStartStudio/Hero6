CONFIG=$1

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

echo "Make sure to build the MonoGame Pipeline extensions if you haven't already"

dotnet test $(dirname $0)/../src/Hero6.sln -c $CONFIG
