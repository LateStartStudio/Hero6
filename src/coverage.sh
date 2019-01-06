# Collect coverage reports
dotnet test ./Collections.Tests/Collections.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Collections.json'
dotnet test ./Search.Tests/Search.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Search.json' -p:MergeWith='../.coverage/Collections.json'
dotnet test ./Hero6.Engine.Tests/Hero6.Engine.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Engine.json' -p:MergeWith='../.coverage/Search.json'
dotnet test ./Hero6.Repository.Tests/Hero6.Repository.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Repository.json' -p:MergeWith='../.coverage/Hero6.Engine.json'
dotnet test ./Hero6.Engine.Campaigns.RitesOfPassage.Tests/Hero6.Engine.Campaigns.RitesOfPassage.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Engine.Campaigns.RitesOfPassage.json' -p:MergeWith='../.coverage/Hero6.Repository.json'
dotnet test ./Hero6.Engine.UserInterfaces.SierraVga.Tests/Hero6.Engine.UserInterfaces.SierraVga.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutput='../.coverage/Hero6.Engine.UserInterfaces.SierraVga.json' -p:MergeWith='../.coverage/Hero6.Engine.Campaigns.RitesOfPassage.json'

# Report to TeamCity
dotnet test ./Hero6.DesktopGL.Tests/Hero6.DesktopGL.Tests.csproj --no-build -p:Configuration=%CONFIGURATION% -p:CollectCoverage=true -p:CoverletOutputFormat=teamcity -p:MergeWith='../.coverage/Hero6.Engine.UserInterfaces.SierraVga.json'
