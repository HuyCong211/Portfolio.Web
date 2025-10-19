# ----- BUILD STAGE -----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Portfolio.Web/Portfolio.Web.csproj", "Portfolio.Web/"]
RUN dotnet restore "Portfolio.Web/Portfolio.Web.csproj"

COPY . .
WORKDIR "/src/Portfolio.Web"
RUN dotnet publish "Portfolio.Web.csproj" -c Release -o /app/publish

# ----- RUNTIME STAGE -----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.Web.dll"]
