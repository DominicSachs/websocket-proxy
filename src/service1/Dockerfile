FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/service1/WorkerService1.csproj", "src/service1/"]
COPY ["src/messages/Messages.csproj", "src/messages/"]
RUN dotnet restore "src/service1/WorkerService1.csproj"
COPY . .
WORKDIR "src/service1"
RUN dotnet build "WorkerService1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerService1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService1.dll"]