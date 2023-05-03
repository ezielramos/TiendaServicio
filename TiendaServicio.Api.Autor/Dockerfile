#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TiendaServicio.Api.Autor/TiendaServicio.Api.Autor.csproj", "TiendaServicio.Api.Autor/"]
RUN dotnet restore "TiendaServicio.Api.Autor/TiendaServicio.Api.Autor.csproj"
COPY . .
WORKDIR "/src/TiendaServicio.Api.Autor"
RUN dotnet build "TiendaServicio.Api.Autor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendaServicio.Api.Autor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicio.Api.Autor.dll"]