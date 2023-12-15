FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/service2/WorkerService2.csproj", "src/service2/"]
COPY ["src/messages/Messages.csproj", "src/messages/"]
RUN dotnet restore "src/service2/WorkerService2.csproj"
COPY . .
WORKDIR "src/service2"
RUN dotnet build "WorkerService2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerService2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService2.dll"]