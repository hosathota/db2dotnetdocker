#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

#ENV LD_LIBRARY_PATH="/app/clidriver/lib"
#ENV LD_LIBRARY_PATH="/app/bin/x64/Debug/netcoreapp3.1/clidriver/lib"
#ENV LD_LIBRARY_PATH="/opt/app-root/src/bin/Release/netcoreapp3.1/clidriver/lib"
ENV LD_LIBRARY_PATH="/opt/app-root/app/clidriver/lib"

RUN apt-get -y update && apt-get install -y libxml2

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DockerTester.csproj", "."]
RUN dotnet restore "./DockerTester.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DockerTester.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerTester.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#Env PATH=$PATH:"/app/bin/x64/Debug/net5.0/clidriver/bin:/app/bin/x64/Debug/net5.0/clidriver/lib"
#Env PATH=$PATH:"/app/bin/x64/Debug/netcoreapp3.1/clidriver/bin:/app/bin/x64/Debug/netcoreapp3.1/clidriver/lib"
Env PATH=$PATH:"/opt/app-root/app/clidriver/bin:/opt/app-root/app/clidriver/lib"

ENTRYPOINT ["dotnet", "DockerTester.dll"]
