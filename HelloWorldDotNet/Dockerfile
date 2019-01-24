FROM microsoft/dotnet:2.2-aspnetcore-runtime 
EXPOSE 80
WORKDIR /app

COPY ./bin/Debug/netcoreapp2.1/publish .
ENTRYPOINT ["dotnet", "HelloWorldDotNet.dll"]