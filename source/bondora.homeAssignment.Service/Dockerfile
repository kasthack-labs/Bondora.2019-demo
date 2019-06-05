FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["bondora.homeAssignment.Service/bondora.homeAssignment.Service.csproj", "bondora.homeAssignment.Service/"]
RUN dotnet restore "bondora.homeAssignment.Service/bondora.homeAssignment.Service.csproj"
COPY . .
WORKDIR "/src/bondora.homeAssignment.Service"
RUN dotnet build "bondora.homeAssignment.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "bondora.homeAssignment.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "bondora.homeAssignment.Service.dll"]