﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserAPI/UserAPI.csproj", "UserAPI/"]
RUN dotnet restore "UserAPI/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserAPI"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAPI.dll"]