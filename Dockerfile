# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Instalar libman
RUN dotnet tool install -g Microsoft.Web.LibraryManager.CLI

# Agregar herramientas .NET global a PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copiar los archivos de solución y proyecto
COPY ["Obligatorio-p2.sln", "./"]
COPY ["web/web.csproj", "web/"]
COPY ["Dominio/", "Dominio/"]

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código fuente
COPY . .

# Restaurar bibliotecas del cliente
WORKDIR /src/web
RUN libman restore

# Publicar la aplicación
WORKDIR /src
RUN dotnet publish "web/web.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Variables de entorno para desarrollo
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 80

ENTRYPOINT ["dotnet", "web.dll"] 