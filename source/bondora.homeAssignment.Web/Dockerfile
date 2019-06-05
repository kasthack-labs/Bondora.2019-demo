FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["bondora.homeAssignment.Web/bondora.homeAssignment.Web.csproj", "bondora.homeAssignment.Web/"]
RUN dotnet restore "bondora.homeAssignment.Web/bondora.homeAssignment.Web.csproj"
COPY . .
WORKDIR "/src/bondora.homeAssignment.Web"
RUN dotnet build "bondora.homeAssignment.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "bondora.homeAssignment.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "bondora.homeAssignment.Web.dll"]