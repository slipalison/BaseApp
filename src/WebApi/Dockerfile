FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WebApi/WebApi.csproj", "src/WebApi/"]
RUN dotnet restore "src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get install -y openssl
RUN mkdir -p /https
RUN openssl req -newkey rsa:2048 -nodes -keyout /https/key.pem -x509 -days 365 -out /https/cert.pem -subj "/C=US/ST=State/L=City/O=Organization/CN=localhost"
ENTRYPOINT ["dotnet", "WebApi.dll"]