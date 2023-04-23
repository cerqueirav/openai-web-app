#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PortalWeb/PortalWeb.csproj", "PortalWeb/"]
RUN dotnet restore "PortalWeb/PortalWeb.csproj"
COPY . .
WORKDIR "/src/PortalWeb"
RUN dotnet build "PortalWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortalWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortalWeb.dll"]