# DeliVeggie App

A microservice-based application built with ASP.NET Core, Angular, MongoDB, and RabbitMQ.

## 🔧 Tech Stack

- **Frontend**: Angular
- **Backend**: ASP.NET Core Web API
- **Message Broker**: RabbitMQ
- **Database**: MongoDB
- **Containerization**: Docker

## 🚀 Setup Instructions

Follow these steps to run the application locally.

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [Node.js (v18+)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [Docker]
- [Docker Desktop](https://www.docker.com/products/docker-desktop) *(optional)*

### Step 1 (To setup and run rabbitmq and mongo db locally + add sample product data to mongo db collections)
- Go to LocalSetup folder and run 'configure-local-rabbitmq-mongo-containers.ps1' script.
- Next run the 'create-mongo-collection-sample-data.ps1' script (make sure the mongo folder is having the MongoDB.Bson, MongoDB.Driver.Core & MongoDB.Driver dll files).

### Step 2 (Set up backend api gateway + background service)
- Go to DeliVeggie Backend folder and open DeliVeggie.sln.
- Build and then Run DeliVeggie API Gateway project.
- Build and then Run a new instance of DeliVeggie.Microservice.Product background service.
  
### Step 3 (Set up angular front end app)
- Open DeliVeggie Frontend folder in vs code and run 'npm install' then 'npm run build' & 'npm run start'.
- Now the front end app will be running in http://localhost:4200.
- Go to http://localhost:4200/product.
