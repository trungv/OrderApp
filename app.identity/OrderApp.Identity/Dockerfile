FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY *.sln .
COPY ["OrderApp.Identity.Services/OrderApp.Identity.Services.csproj", "OrderApp.Identity.Services/"]
RUN dotnet restore
COPY . .

RUN dotnet build --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApp.Identity.Services.dll"]
