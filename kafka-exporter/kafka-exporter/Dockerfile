FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["kafka-exporter/kafka-exporter.csproj", "kafka-exporter/"]
RUN dotnet restore "kafka-exporter/kafka-exporter.csproj"
COPY . .
WORKDIR "/src/kafka-exporter"
RUN dotnet build "kafka-exporter.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "kafka-exporter.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "kafka-exporter.dll"]
