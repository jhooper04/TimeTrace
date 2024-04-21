#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TimeTrace.Web/TimeTrace.Web.csproj", "src/TimeTrace.Web/"]
COPY ["src/TimeTrace.Application/TimeTrace.Application.csproj", "src/TimeTrace.Application/"]
COPY ["src/TimeTrace.Domain/Domain.csproj", "src/TimeTrace.Domain/"]
COPY ["src/TimeTrace.Infrastructure/Infrastructure.csproj", "src/TimeTrace.Infrastructure/"]
RUN dotnet restore "./src/TimeTrace.Web/TimeTrace.Web.csproj"
COPY . .
WORKDIR "/src/src/TimeTrace.Web"
RUN dotnet build "./TimeTrace.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeTrace.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeTrace.Web.dll"]