# Game of live

## Prerequisite
NET Core SDK 1.0.1

## Run application
- cd Application
- dotnet restore
- dotnet run
## Run tests
- dotnet restore ./Domain.Tests/Domain.Tests.csproj
 - dotnet test ./Domain.Tests/Domain.Tests.csproj
 - dotnet restore ./Application.Tests/Application.Tests.csproj
 - dotnet test ./Application.Tests/Application.Tests.csproj
