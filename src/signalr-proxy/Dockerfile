FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/signalr-proxy/SignalrProxy.csproj", "src/signalr-proxy/"]
COPY ["src/messages/Messages.csproj", "src/messages/"]
RUN dotnet restore "src/signalr-proxy/SignalrProxy.csproj"
COPY . .
WORKDIR "src/signalr-proxy"
RUN dotnet build "SignalrProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalrProxy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalrProxy.dll"]
