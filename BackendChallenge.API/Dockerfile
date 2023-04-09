#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BackendChallenge.API/BackendChallenge.API.csproj", "BackendChallenge.API/"]
RUN dotnet restore "BackendChallenge.API/BackendChallenge.API.csproj"
COPY . .
WORKDIR "/src/BackendChallenge.API"
RUN dotnet build "BackendChallenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendChallenge.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendChallenge.API.dll"]