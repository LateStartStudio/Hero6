CONFIG=$1
PROJECTS=(Collections Search Hero6.Engine Hero6.Repository Hero6.Engine.Campaigns.RitesOfPassage Hero6.Engine.UserInterfaces.SierraVga Hero6.DesktopGL)

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

make_opencover_report()
{
  NAME=$1

  dotnet test $(dirname $0)/../src/$NAME.Tests/$NAME.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutputFormat=opencover -p:CoverletOutput="../.coverage/opencover/${NAME}.xml"
}

echo "Cleaning previous coverage reports"
rm -rf $(dirname $0)/../src/.coverage/

echo "Collect opencover reports"
for PROJECT in "${PROJECTS[@]}"
do
  make_opencover_report $PROJECT
done

echo "Make human readable coverage reports"
REPORTS=-reports:
for PROJECT in "${PROJECTS[@]}"
do
  REPORTS=$REPORTS$(dirname $0)/../src/.coverage/opencover/$PROJECT.xml\;
done
dotnet $(dirname $0)/../src/packages/ReportGenerator/tools/netcoreapp2.0/ReportGenerator.dll "$REPORTS" "-targetdir:$(dirname $0)/../src/.coverage/html" -reporttypes:HTML
mv $(dirname $0)/../src/.coverage/html/index.htm $(dirname $0)/../src/.coverage/html/index.html

echo "Coverage reports generated at ./src/.coverage/"
