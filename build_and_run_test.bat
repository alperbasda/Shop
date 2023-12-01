@echo off
echo Building the .NET Core project...
dotnet build \Presentation\Shop.UI.ApiShop.UI.Api.csproj

echo Running unit tests...
dotnet test
pause