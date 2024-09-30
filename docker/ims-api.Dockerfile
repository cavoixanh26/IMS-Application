# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IMS.API/IMS.Api.csproj", "IMS.API/"]
COPY ["IMS.BusinessService/IMS.BusinessService.csproj", "IMS.BusinessService/"]
COPY ["IMS.Contract/IMS.Contract.csproj", "IMS.Contract/"]
COPY ["IMS.Domain/IMS.Domain.csproj", "IMS.Domain/"]
COPY ["IMS.Infrastructure/IMS.Infrastructure.csproj", "IMS.Infrastructure/"]
RUN dotnet restore "./IMS.API/IMS.Api.csproj"

# Install dockerize in the build stage
RUN apt-get update && apt-get install -y wget \
    && wget https://github.com/jwilder/dockerize/releases/download/v0.6.1/dockerize-linux-amd64-v0.6.1.tar.gz \
    && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-v0.6.1.tar.gz \
    && rm dockerize-linux-amd64-v0.6.1.tar.gz

COPY . .
WORKDIR "/src/IMS.API"
RUN dotnet build "./IMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copy dockerize from the build stage to the final stage
COPY --from=build /usr/local/bin/dockerize /usr/local/bin/dockerize

# Apply migrations before running the application
ENTRYPOINT ["dockerize", "-wait", "tcp://ims-db:1433", "-timeout", "60s", "dotnet", "IMS.Api.dll"]
