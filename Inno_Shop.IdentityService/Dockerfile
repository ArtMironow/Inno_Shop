FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /Inno_Shop.IdentityService/src
COPY ["Inno_Shop.IdentityService/src/Inno_Shop.IdentityService.Api/Inno_Shop.IdentityService.Api.csproj", "Inno_Shop.IdentityService.Api/"]
COPY ["Inno_Shop.IdentityService/src/Inno_Shop.IdentityService.Application/Inno_Shop.IdentityService.Application.csproj", "Inno_Shop.IdentityService.Application/"]
COPY ["Inno_Shop.IdentityService/src/Inno_Shop.IdentityService.Domain/Inno_Shop.IdentityService.Domain.csproj", "Inno_Shop.IdentityService.Domain/"]
COPY ["Inno_Shop.IdentityService/src/Inno_Shop.IdentityService.Contracts/Inno_Shop.IdentityService.Contracts.csproj", "Inno_Shop.IdentityService.Contracts/"]
COPY ["Inno_Shop.IdentityService/src/Inno_Shop.IdentityService.Infrastructure/Inno_Shop.IdentityService.Infrastructure.csproj", "Inno_Shop.IdentityService.Infrastructure/"]
RUN dotnet restore "Inno_Shop.IdentityService.Api/Inno_Shop.IdentityService.Api.csproj"
COPY . /
WORKDIR /Inno_Shop.IdentityService/src/Inno_Shop.IdentityService.Api
RUN dotnet build "Inno_Shop.IdentityService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inno_Shop.IdentityService.Api.dll"]