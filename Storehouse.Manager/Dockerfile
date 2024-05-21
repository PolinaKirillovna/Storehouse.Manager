FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Storehouse.Manager/Storehouse.Manager.csproj", "Storehouse.Manager/"]
RUN dotnet restore "Storehouse.Manager/Storehouse.Manager.csproj"
COPY . .
WORKDIR "/src/Storehouse.Manager"
RUN dotnet build "Storehouse.Manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Storehouse.Manager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Storehouse.Manager.dll"]
