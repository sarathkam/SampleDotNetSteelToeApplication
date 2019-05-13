FROM microsoft/dotnet:2.2-aspnetcore-runtime 
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://+:5000
WORKDIR /app

COPY ./bin/Debug/netcoreapp2.1/publish .
ENTRYPOINT ["dotnet", "HelloWorldDotNet.dll"]