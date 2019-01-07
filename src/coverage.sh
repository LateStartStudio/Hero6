CONFIG=$1
if [ -z "$CODECOV_TOKEN" ]; then
    CODECOV_TOKEN=$2
fi

# Collect coverage reports
dotnet test ./Collections.Tests/Collections.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Collections.json'
dotnet test ./Search.Tests/Search.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Search.json' -p:MergeWith='../.coverage/Collections.json'
dotnet test ./Hero6.Engine.Tests/Hero6.Engine.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Engine.json' -p:MergeWith='../.coverage/Search.json'
dotnet test ./Hero6.Repository.Tests/Hero6.Repository.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Repository.json' -p:MergeWith='../.coverage/Hero6.Engine.json'
dotnet test ./Hero6.Engine.Campaigns.RitesOfPassage.Tests/Hero6.Engine.Campaigns.RitesOfPassage.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Engine.Campaigns.RitesOfPassage.json' -p:MergeWith='../.coverage/Hero6.Repository.json'
dotnet test ./Hero6.Engine.UserInterfaces.SierraVga.Tests/Hero6.Engine.UserInterfaces.SierraVga.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Engine.UserInterfaces.SierraVga.json' -p:MergeWith='../.coverage/Hero6.Engine.Campaigns.RitesOfPassage.json'
dotnet test ./Hero6.DesktopGL.Tests/Hero6.DesktopGL.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.json' -p:MergeWith='../.coverage/Hero6.Engine.UserInterfaces.SierraVga.json'

# Report to TeamCity
dotnet test ./Hero6.DesktopGL.Tests/Hero6.DesktopGL.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutputFormat=teamcity -p:MergeWith='../.coverage/Hero6.Engine.UserInterfaces.SierraVga.json'

# Report to Codecov
dotnet test ./Hero6.DesktopGL.Tests/Hero6.DesktopGL.Tests.csproj --no-build -p:Configuration=$CONFIG -p:CollectCoverage=true -p:CoverletOutputFormat=opencover -p:CoverletOutput='../.coverage/Hero6.xml' -p:MergeWith='../.coverage/Hero6.Engine.UserInterfaces.SierraVga.json'
chmod +x ./packages/Codecov/tools/codecov.exe
./packages/Codecov/tools/codecov.exe -f "./.coverage/Hero6.xml" -t $CODECOV_TOKEN
