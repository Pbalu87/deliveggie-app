# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the main Web API project file
COPY DeliVeggie.Microservice.Product/DeliVeggie.Microservice.Product.csproj ./DeliVeggie.Microservice.Product/

# Copy the class library project files
COPY DeliVeggie.Infrastructure.MongoDb/DeliVeggie.Infrastructure.MongoDb.csproj ./DeliVeggie.Infrastructure.MongoDb/
COPY DeliVeggie.Infrastructure.RabbitMQ/DeliVeggie.Infrastructure.RabbitMQ.csproj ./DeliVeggie.Infrastructure.RabbitMQ/

# Restore dependencies
RUN dotnet restore ./DeliVeggie.Microservice.Product/DeliVeggie.Microservice.Product.csproj

# Copy all source code into image
COPY .. .

# Build the application
WORKDIR /src/DeliVeggie.Microservice.Product
RUN dotnet build DeliVeggie.Microservice.Product.csproj -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish DeliVeggie.Microservice.Product.csproj -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DeliVeggie.Microservice.Product.dll"]
