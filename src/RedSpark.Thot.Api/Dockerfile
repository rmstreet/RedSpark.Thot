FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/RedSpark.Thot.Api/RedSpark.Thot.Api.csproj", "src/RedSpark.Thot.Api/"]
RUN dotnet restore "src/RedSpark.Thot.Api/RedSpark.Thot.Api.csproj"
COPY . .
WORKDIR "/src/src/RedSpark.Thot.Api"
RUN dotnet build "RedSpark.Thot.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RedSpark.Thot.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RedSpark.Thot.Api.dll"]