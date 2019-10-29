FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OrderApp.Messages.EmailService/OrderApp.Messages.EmailService.csproj", "OrderApp.Messages.EmailService/"]
RUN dotnet restore "OrderApp.Messages.EmailService/OrderApp.Messages.EmailService.csproj"
COPY . .
WORKDIR "/src/OrderApp.Messages.EmailService"
RUN dotnet build "OrderApp.Messages.EmailService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApp.Messages.EmailService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApp.Messages.EmailService.dll"]