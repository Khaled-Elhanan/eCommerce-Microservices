# eCommerce Microservices Monorepo

This repository is organized as a professional Microservices monorepo architecture.

## Repository Structure

```
eCommerce-Microservices
│
├── 01. Users Microservice/
│   ├── eCommerce.API/                     # Web API presentation layer
│   ├── eCommerce.Core/                    # Domain models, DTOs, interfaces, services
│   ├── eCommerce.Infrastructure/          # Data access (Dapper, Npgsql, Repositories)
│   ├── eCommerceSolution.UserService.sln   # Visual Studio Solution (.sln)
│   └── eCommerce.Solution.UserService.slnx # Solution file (.slnx)
│
├── 02. Products Microservice/
│   ├── ProductsMicroService.API/          # Web API presentation layer
│   ├── ProductsMicroService.Core/         # Domain models, DTOs, interfaces, services
│   ├── ProductsMicroService.Infrastructure/ # Data access layer
│   ├── ProductsMicroService.sln          # Visual Studio Solution (.sln)
│   └── ProductsMicroService.slnx         # Solution file (.slnx)
```

## Building the Solutions

### Build Users Microservice
```bash
dotnet build "01. Users Microservice/eCommerceSolution.UserService.sln"
```

### Build Products Microservice
```bash
dotnet build "02. Products Microservice/ProductsMicroService.sln"
```
