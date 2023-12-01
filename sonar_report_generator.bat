dotnet sonarscanner begin /o:abasda /k:"abasda_abasda" /d:sonar.login="9dc0c95fa0ca20d8cdf337e0e2897da3c8cd7ee0" /d:sonar.host.url="https://sonarcloud.io"  /d:sonar.cs.dotcover.reportsPaths="C:\Users\Admin\source\repos\ShopRu\Shop\TestResults\527d7895-e7e5-481c-b7b1-e386fc55f129"
dotnet build
dotnet sonarscanner end /d:sonar.login="9dc0c95fa0ca20d8cdf337e0e2897da3c8cd7ee0"