FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY *.sln .
COPY ["OrderApp.Messages.EmailGrpcService/OrderApp.Messages.EmailGrpcService.csproj", "OrderApp.Messages.EmailGrpcService/"]
RUN dotnet restore
COPY . .

RUN dotnet build --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApp.Messages.EmailGrpcService.dll"]
