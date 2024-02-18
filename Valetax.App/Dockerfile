FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Valetax.App/Valetax.App.csproj", "Valetax.App/"]
COPY ["Valetax.Services/Valetax.Services.csproj", "Valetax.Services/"]
COPY ["Valetax.Db/Valetax.Db.csproj", "Valetax.Db/"]
RUN dotnet restore "Valetax.App/Valetax.App.csproj"
COPY . .
WORKDIR "/src/Valetax.App"
RUN dotnet build "Valetax.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Valetax.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Valetax.App.dll"]
