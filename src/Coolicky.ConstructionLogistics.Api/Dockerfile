FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Coolicky.ConstructionLogistics.Api/Coolicky.ConstructionLogistics.Api.csproj", "Coolicky.ConstructionLogistics.Api/"]
RUN dotnet restore "Coolicky.ConstructionLogistics.Api/Coolicky.ConstructionLogistics.Api.csproj"
COPY . .
WORKDIR "/src/Coolicky.ConstructionLogistics.Api"
RUN dotnet build "Coolicky.ConstructionLogistics.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coolicky.ConstructionLogistics.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coolicky.ConstructionLogistics.Api.dll"]