dotnet sonarscanner begin /o:abasda /k:"abasda_abasda" /d:sonar.login="9dc0c95fa0ca20d8cdf337e0e2897da3c8cd7ee0" /d:sonar.host.url="https://sonarcloud.io" 
dotnet build
dotnet sonarscanner end /d:sonar.login="9dc0c95fa0ca20d8cdf337e0e2897da3c8cd7ee0"