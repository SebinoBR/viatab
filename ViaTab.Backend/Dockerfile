FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ViaTab.Backend.csproj", "."]
RUN dotnet restore "ViaTab.Backend.csproj"
COPY . .
RUN dotnet build "ViaTab.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ViaTab.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ViaTab.Backend.dll"]