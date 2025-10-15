# Etapa base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AppLucas/AppLucas.csproj", "AppLucas/"]
RUN dotnet restore "AppLucas/AppLucas.csproj"
COPY . .
WORKDIR "/src/AppLucas"
RUN dotnet build "AppLucas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppLucas.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppLucas.dll"]
