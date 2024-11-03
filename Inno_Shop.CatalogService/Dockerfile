FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /Inno_Shop.CatalogService/src
COPY ["Inno_Shop.CatalogService/src/Inno_Shop.CatalogService.Api/Inno_Shop.CatalogService.Api.csproj", "Inno_Shop.CatalogService.Api/"]
COPY ["Inno_Shop.CatalogService/src/Inno_Shop.CatalogService.Application/Inno_Shop.CatalogService.Application.csproj", "Inno_Shop.CatalogService.Application/"]
COPY ["Inno_Shop.CatalogService/src/Inno_Shop.CatalogService.Domain/Inno_Shop.CatalogService.Domain.csproj", "Inno_Shop.CatalogService.Domain/"]
COPY ["Inno_Shop.CatalogService/src/Inno_Shop.CatalogService.Contracts/Inno_Shop.CatalogService.Contracts.csproj", "Inno_Shop.CatalogService.Contracts/"]
COPY ["Inno_Shop.CatalogService/src/Inno_Shop.CatalogService.Infrastructure/Inno_Shop.CatalogService.Infrastructure.csproj", "Inno_Shop.CatalogService.Infrastructure/"]
RUN dotnet restore "Inno_Shop.CatalogService.Api/Inno_Shop.CatalogService.Api.csproj"
COPY . /
WORKDIR /Inno_Shop.CatalogService/src/Inno_Shop.CatalogService.Api
RUN dotnet build "Inno_Shop.CatalogService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5003
EXPOSE 5003
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inno_Shop.CatalogService.Api.dll"]