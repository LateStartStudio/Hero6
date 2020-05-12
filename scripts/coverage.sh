#!/bin/bash

CONFIG=$1
PROJECTS=(Collections Search Hero6.Engine.Desktop Hero6.Repository Hero6.Campaigns.RitesOfPassage Hero6.UserInterfaces.SierraVga Hero6.Desktop)

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

echo "Collect reports"
for PROJECT in "${PROJECTS[@]}"
do
  dotnet coverlet $(dirname $0)/../src/${PROJECT}.Tests/bin/$CONFIG/*/${PROJECT}.Tests.dll --target "dotnet" --targetargs "test $(dirname $0)/../src/${PROJECT}.Tests/${PROJECT}.Tests.csproj --configuration ${CONFIG} --no-build" --output "$(dirname $0)/../src/.coverage/cobertura/${CONFIG}/${PROJECT}.xml" --format cobertura
done

echo "Make human readable coverage reports"
dotnet reportgenerator "-reports:$(dirname $0)/../src/.coverage/cobertura/${CONFIG}/*.xml" "-targetdir:$(dirname $0)/../src/.coverage/html/${CONFIG}" -reporttypes:HtmlInline_AzurePipelines

echo "Coverage reports generated at ./src/.coverage/"
