# Version: 0.0.1
FROM microsoft/aspnetcore:1.1.2
MAINTAINER Rob Swartenbroekx "rob.swartenbroekx@gmail.com"
WORKDIR /app
COPY app .
RUN useradd app
USER app
EXPOSE 5001
ENTRYPOINT ["dotnet", "Application.dll"]

