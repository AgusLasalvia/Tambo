# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de solución y proyecto
COPY ["Obligatorio-p2.sln", "./"]
COPY ["web/web.csproj", "web/"]
COPY ["Dominio/", "Dominio/"]

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código fuente
COPY . .

# Publicar la aplicación
RUN dotnet publish "web/web.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "web.dll"] 