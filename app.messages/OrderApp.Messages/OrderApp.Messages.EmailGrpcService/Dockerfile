FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["OrderApp.Messages.EmailGrpcService/OrderApp.Messages.EmailGrpcService.csproj", "OrderApp.Messages.EmailGrpcService/"]
RUN dotnet restore "OrderApp.Messages.EmailGrpcService/OrderApp.Messages.EmailGrpcService.csproj"
COPY . .
WORKDIR "/src/OrderApp.Messages.EmailGrpcService"
RUN dotnet build "OrderApp.Messages.EmailGrpcService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApp.Messages.EmailGrpcService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApp.Messages.EmailGrpcService.dll"]