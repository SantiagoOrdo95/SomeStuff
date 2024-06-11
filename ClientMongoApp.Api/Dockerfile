#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClientMongoApp.Api/ClientMongoApp.Api.csproj", "ClientMongoApp.Api/"]
COPY ["ClientMongoApp.Core/ClientMongoApp.Core.csproj", "ClientMongoApp.Core/"]
COPY ["ClientMongoApp.Application/ClientMongoApp.Application.csproj", "ClientMongoApp.Application/"]
COPY ["ClientMongoApp.Infrastructure/ClientMongoApp.Infrastructure.csproj", "ClientMongoApp.Infrastructure/"]
RUN dotnet restore "./ClientMongoApp.Api/ClientMongoApp.Api.csproj"

WORKDIR "/src/ClientMongoApp.Api"
RUN dotnet build "./ClientMongoApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClientMongoApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientMongoApp.Api.dll"]