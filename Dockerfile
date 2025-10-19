# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj and restore
COPY Portfolio.Web/Portfolio.Web.csproj ./Portfolio.Web/
RUN dotnet restore "./Portfolio.Web/Portfolio.Web.csproj"

# Copy everything else and build
COPY . .
WORKDIR /src/Portfolio.Web
RUN dotnet publish -c Release -o /app/out

# =========================
# Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Portfolio.Web.dll"]
