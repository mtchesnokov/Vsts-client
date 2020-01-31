msbuild /p:configuration=Release

nuget push bin\Release\*.nupkg -source Offline -apikey vsts 

del bin\Release\*.nupkg