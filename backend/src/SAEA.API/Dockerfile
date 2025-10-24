# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SAEA.API/SAEA.API.csproj", "src/SAEA.API/"]
COPY ["src/SAEA.Application/SAEA.Application.csproj", "src/SAEA.Application/"]
COPY ["src/SAEA.DataTransfer/SAEA.DataTransfer.csproj", "src/SAEA.DataTransfer/"]
COPY ["src/SAEA.Domain/SAEA.Domain.csproj", "src/SAEA.Domain/"]
COPY ["src/SAEA.IoC/SAEA.IoC.csproj", "src/SAEA.IoC/"]
COPY ["src/SAEA.Infrastructure/SAEA.Infrastructure.csproj", "src/SAEA.Infrastructure/"]
RUN dotnet restore "./src/SAEA.API/SAEA.API.csproj"
COPY . .
WORKDIR "/src/src/SAEA.API"
RUN dotnet build "./SAEA.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SAEA.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SAEA.API.dll"]