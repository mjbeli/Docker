# This dockerfile is based on
# https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile.ubuntu-x64
# https://hub.docker.com/_/microsoft-dotnet-core
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS build
WORKDIR /source

# copy csproj and restore as distinct layers
#COPY *.sln .
#COPY WebSampleApp/*.csproj ./WebSampleApp/
#RUN dotnet restore -r linux-x64

# copy everything else and build app
COPY WebSampleApp/. ./WebSampleApp
WORKDIR WebSampleApp
RUN dotnet restore -r linux-x64
RUN dotnet publish -c release -o /Publish -r linux-x64 --self-contained false --no-restore

EXPOSE 80

# final stage/image
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
#WORKDIR /app
#COPY --from=build source/WebSampleApp/Publish ./Publish
#COPY /WebSampleApp/Publish ./Publish
ENTRYPOINT ["dotnet", "source/WebSampleApp/Publish/WebSampleApp.dll"]
