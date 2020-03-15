# This dockerfile is based on
# https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile.ubuntu-x64
# https://hub.docker.com/_/microsoft-dotnet-core

# This first image is just for compile purpuoses, SDK image for restore and publish.
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
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
# This image is just for Execute ASP.NET CORE Dlls in ubuntu x64. This image cann't compile or build.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
# Copy from build image (where the published DLLs are), to the current image base
COPY --from=build source/WebSampleApp/Publish ./Publish
ENTRYPOINT ["dotnet", "./Publish/WebSampleApp.dll"]
