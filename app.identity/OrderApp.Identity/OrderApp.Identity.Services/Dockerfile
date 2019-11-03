FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OrderApp.Identity.Services/OrderApp.Identity.Services.csproj", "OrderApp.Identity.Services/"]
RUN dotnet restore "OrderApp.Identity.Services/OrderApp.Identity.Services.csproj"
COPY . .
WORKDIR "/src/OrderApp.Identity.Services"
RUN dotnet build "OrderApp.Identity.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApp.Identity.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApp.Identity.Services.dll"]