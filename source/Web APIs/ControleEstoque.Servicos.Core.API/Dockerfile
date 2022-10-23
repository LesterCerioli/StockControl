#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["source/Web APIs/ControleEstoque.Servicos.Core.API/ControleEstoque.Servicos.Core.API.csproj", "source/Web APIs/ControleEstoque.Servicos.Core.API/"]
RUN dotnet restore "source/Web APIs/ControleEstoque.Servicos.Core.API/ControleEstoque.Servicos.Core.API.csproj"
COPY . .
WORKDIR "/src/source/Web APIs/ControleEstoque.Servicos.Core.API"
RUN dotnet build "ControleEstoque.Servicos.Core.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControleEstoque.Servicos.Core.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControleEstoque.Servicos.Core.API.dll"]