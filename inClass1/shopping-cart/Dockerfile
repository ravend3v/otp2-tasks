FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .

# publish the actual project file (shopping-cart.csproj)
RUN dotnet publish src/shopping-cart.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/publish ./
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# use the actual output DLL name (case-sensitive on Linux)
ENTRYPOINT ["dotnet", "shopping-cart.dll"]
