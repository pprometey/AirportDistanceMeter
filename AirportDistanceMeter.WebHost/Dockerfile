#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AirportDistanceMeter.WebHost/AirportDistanceMeter.WebHost.csproj", "AirportDistanceMeter.WebHost/"]
COPY ["AirportDistanceMeter.Infrastructure/AirportDistanceMeter.Infrastructure.csproj", "AirportDistanceMeter.Infrastructure/"]
COPY ["AirportDistanceMeter.Domain/AirportDistanceMeter.Domain.csproj", "AirportDistanceMeter.Domain/"]
COPY ["AirportDistanceMeter.Application/AirportDistanceMeter.Application.csproj", "AirportDistanceMeter.Application/"]
COPY ["Common.Infrastructure.Tools/Common.Infrastructure.Tools.csproj", "Common.Infrastructure.Tools/"]
RUN dotnet restore "AirportDistanceMeter.WebHost/AirportDistanceMeter.WebHost.csproj"
COPY . .
WORKDIR "/src/AirportDistanceMeter.WebHost"
RUN dotnet build "AirportDistanceMeter.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirportDistanceMeter.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportDistanceMeter.WebHost.dll"]