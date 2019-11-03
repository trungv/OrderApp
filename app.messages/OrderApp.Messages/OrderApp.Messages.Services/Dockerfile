FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OrderApp.Messages.Services/OrderApp.Messages.Services.csproj", "OrderApp.Messages.Services/"]
RUN dotnet restore "OrderApp.Messages.Services/OrderApp.Messages.Services.csproj"
COPY . .
WORKDIR "/src/OrderApp.Messages.Services"
RUN dotnet build "OrderApp.Messages.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApp.Messages.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApp.Messages.Services.dll"]