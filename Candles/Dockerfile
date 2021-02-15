#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Candles/Candles.csproj", "Candles/"]
COPY ["CandleComposing/CandleComposing.csproj", "CandleComposing/"]
COPY ["Factories/Factories.csproj", "Factories/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Unity/Unity.csproj", "Unity/"]
RUN dotnet restore "Candles/Candles.csproj"
COPY . .
WORKDIR "/src/Candles"
RUN dotnet build "Candles.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Candles.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Candles.dll"]