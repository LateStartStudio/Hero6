CONFIG=$1

if [ -x $CONFIG ]; then
  echo 'Missing parameter $CONFIG'
  exit 1
fi

make_opencover_report()
{
  NAME=$1

  dotnet test ./$NAME.Tests/$NAME.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutputFormat=opencover -p:CoverletOutput="../.coverage/opencover/${NAME}.xml"
}

echo "Collect opencover reports"
make_opencover_report Collections
make_opencover_report Search
make_opencover_report Hero6.Engine
make_opencover_report Hero6.Repository
make_opencover_report Hero6.Engine.Campaigns.RitesOfPassage
make_opencover_report Hero6.Engine.UserInterfaces.SierraVga
make_opencover_report Hero6.DesktopGL

echo "Make human readable coverage reports"
dotnet ./packages/ReportGenerator/tools/netcoreapp2.0/ReportGenerator.dll "-reports:./.coverage/opencover/Hero6.DesktopGL.xml;./.coverage/opencover/Collections.xml;./.coverage/opencover/Search.xml;./.coverage/opencover/Hero6.Engine.xml;./.coverage/opencover/Hero6.Repository.xml;./.coverage/opencover/Hero6.Engine.Campaigns.RitesOfPassage.xml;./.coverage/opencover/Hero6.Engine.UserInterfaces.SierraVga.xml" "-targetdir:./.coverage/html" -reporttypes:HTML
mv ./.coverage/html/index.htm ./.coverage/html/index.html
