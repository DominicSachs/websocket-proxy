FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

RUN apt-get update && apt-get install -y curl

COPY ["certificates/RootCA.crt", "/usr/local/share/ca-certificates/RootCA.crt"]
RUN update-ca-certificates

EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/api/Api.csproj", "src/api/"]
RUN dotnet restore "src/api/Api.csproj"
COPY . .
WORKDIR "/src/src/api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]