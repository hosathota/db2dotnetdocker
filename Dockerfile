
##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
##For .NET 5.0
#FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
###For .NET Core 3.1
##FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
#
#WORKDIR /app
   #
##incase of any library loading issues, enabled the next line to collect more information
##ENV LD_DEBUG=bindings:symbols
#
##Make sure the path is set to location where clidriver is present. For .NET Core, the path will vary
#ENV LD_LIBRARY_PATH="/app/clidriver/lib"
##ENV LD_LIBRARY_PATH="/app/bin/x64/Debug/net5.0/clidriver/lib"
#
##install the dependency library libxml2
#RUN apt-get -y update && apt-get install -y libxml2
#
##For .NET Core 3.1 it will be FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#
#COPY . ./
#RUN dotnet restore "./DockerTest6.csproj"
#
#RUN dotnet build "DockerTest6.csproj" -c Release -o /app/build
##RUN dotnet build "DockerTest6.csproj" -c Debug -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DockerTest6.csproj" -c Release -o /app/publish
##RUN dotnet publish "DockerTest6.csproj" -c Debug -o /app/publish
  #
###In some cases, for applications targeting IBM database servers IBM i or zOS, the license file may have to be copied explicitly and NuGet
###cache is one of the location to keep the license file
#COPY ./db2consv_zs.lic /app/publish/clidriver/license/db2consv_zs.lic
#
#FROM base AS final
#WORKDIR /app
#
#COPY --from=publish /app/publish .
#
#Env PATH=$PATH:"/app/bin/x64/Release/net5.0/clidriver/bin:/app/bin/x64/Release/net5.0/clidriver/lib"
##Env PATH=$PATH:"/app/bin/x64/Debug/net5.0/clidriver/bin:/app/bin/x64/Debug/net5.0/clidriver/lib"
#
#ENTRYPOINT ["dotnet", "DockerTest6.dll"]  

#For Debug mode
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#For .NET 5.0
FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
##For .NET Core 3.1
#FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base

WORKDIR /app
   
#incase of any library loading issues, enabled the next line to collect more information
#ENV LD_DEBUG=bindings:symbols

#Make sure the path is set to location where clidriver is present. For .NET Core, the path will vary
#ENV LD_LIBRARY_PATH="/app/clidriver/lib"
ENV LD_LIBRARY_PATH="/app/bin/x64/Debug/net5.0/clidriver/lib"

#install the dependency library libxml2
RUN apt-get -y update && apt-get install -y libxml2

#For .NET Core 3.1 it will be FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore "./DockerTest6.csproj"

#RUN dotnet build "DockerTest6.csproj" -c Release -o /app/build
RUN dotnet build "DockerTest6.csproj" -c Debug -o /app/build

FROM build AS publish
#RUN dotnet publish "DockerTest6.csproj" -c Release -o /app/publish
RUN dotnet publish "DockerTest6.csproj" -c Debug -o /app/publish
  
##In some cases, for applications targeting IBM database servers IBM i or zOS, the license file may have to be copied explicitly and NuGet
##cache is one of the location to keep the license file
##For Release
#COPY ./db2consv_zs.lic /app/publish/clidriver/license/db2consv_zs.lic
##For Debug
#COPY ./db2consv_zs.lic /app/bin/x64/Debug/net5.0/clidriver/license/
COPY ./db2consv_zs.lic /app/publish/clidriver/license/db2consv_zs.lic

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

#COPY ./db2consv_zs.lic /app/bin/x64/Debug/net5.0/clidriver/license/db2consv_zs.lic
#COPY /app/bin/x64/Debug/net5.0/db2consv_zs.lic /app/bin/x64/Debug/net5.0/clidriver/license/
##COPY ./db2consv_zs.lic ./clidriver/license/db2consv_zs.lic

#Env PATH=$PATH:"/app/bin/x64/Release/net5.0/clidriver/bin:/app/bin/x64/Release/net5.0/clidriver/lib"
Env PATH=$PATH:"/app/bin/x64/Debug/net5.0/clidriver/bin:/app/bin/x64/Debug/net5.0/clidriver/lib"

ENTRYPOINT ["dotnet", "DockerTest6.dll"]  
