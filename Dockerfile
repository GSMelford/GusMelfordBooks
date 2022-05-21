#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0.3-bullseye-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0.201-bullseye-slim-arm64v8 AS build
WORKDIR /src
COPY ["GusMelfordBooks.API/GusMelfordBooks.API.csproj", "GusMelfordBooks.API/"]
COPY ["GusMelfordBooks.Infrastructure/GusMelfordBooks.Infrastructure.csproj", "GusMelfordBooks.Infrastructure/"]
COPY ["GusMelfordBooks.Domain/GusMelfordBooks.Domain.csproj", "GusMelfordBooks.Domain/"]
COPY ["GusMelfordBooks.CustomExceptions/GusMelfordBooks.CustomExceptions.csproj", "GusMelfordBooks.CustomExceptions/"]
COPY ["GusMelfordBooks.Repositories/GusMelfordBooks.Repositories.csproj", "GusMelfordBooks.Repositories/"]
COPY ["GusMelfordBooks.Services/GusMelfordBooks.Services.csproj", "GusMelfordBooks.Services/"]
COPY ["GusMelfordBooks.Extensions/GusMelfordBooks.Extensions.csproj", "GusMelfordBooks.Extensions/"]
RUN dotnet restore "GusMelfordBooks.API/GusMelfordBooks.API.csproj"
COPY . .
WORKDIR "/src/GusMelfordBooks.API"
RUN dotnet build "GusMelfordBooks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GusMelfordBooks.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GusMelfordBooks.API.dll"]