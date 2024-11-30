FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
COPY NuGet.config ./
COPY Directory.Build.props ./
COPY Directory.Packages.props ./
COPY Domain/Domain.csproj Domain/
COPY Persistence/Persistence.csproj Persistence/
COPY Persistence.Contracts/Persistence.Contracts.csproj Persistence.Contracts/
COPY Application/Application.csproj Application/
COPY Application.Contracts/Application.Contracts.csproj Application.Contracts/
COPY Web/Web.csproj Web/
RUN dotnet restore Web/Web.csproj
COPY . .
RUN dotnet build Web/Web.csproj -c Release -o app/build

FROM build AS publish
RUN dotnet publish Web/Web.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT dotnet Web.dll