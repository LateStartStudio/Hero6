#!/bin/bash

CONFIG=$1
PROJECTS=(Collections Search Hero6.Engine Hero6.Repository Hero6.Engine.Campaigns.RitesOfPassage Hero6.Engine.UserInterfaces.SierraVga Hero6.DesktopGL)

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

echo "Collect reports"
for PROJECT in "${PROJECTS[@]}"
do
  dotnet test $(dirname $0)/../src/${PROJECT}.Tests/${PROJECT}.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura -p:CoverletOutput="../.coverage/cobertura/${PROJECT}.${CONFIG}.xml"
done

echo "Make human readable coverage reports"
dotnet $(dirname $0)/../src/packages/ReportGenerator/tools/netcoreapp2.0/ReportGenerator.dll "-reports:$(dirname $0)/../src/.coverage/cobertura/*.xml" "-targetdir:$(dirname $0)/../src/.coverage/html" -reporttypes:HtmlInline_AzurePipelines

echo "Coverage reports generated at ./src/.coverage/"
