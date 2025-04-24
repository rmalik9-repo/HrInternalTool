
# HR Management Web API (.NET 8 - Clean Architecture)

## 📌 Overview

This is a RESTful Web API built using .Net 8 Web API with Entity Framework Core (Code-First), and SQL Server. It follows Clean Architecture with well-defined separation of concerns (Domain, Application, Infrastructure, and API layers). The API serves as the backend for an internal HR tool allowing HR professionals to:

- Manage employee records  
- Track performance reviews  
- Generate analytical insights  

---

## Architecture

- **Clean Architecture** with layered separation:  
  - **Domain**: Core business logic, entities, and interfaces  
  - **Application**: Use cases, Command, Queries validators, and service abstractions  
  - **Infrastructure**: Migration, Data, Repositories, External dependencies   
  - **API**: Controllers, Swagger, middlewares, DI container, versioning  

- **Design Patterns & Principles**:  
  - Repository  
  - SOLID Principles  
  - MediatR for decoupled request handling  

---

## Tech Stack

- .NET 8: Web API backend  
- EF Core: Code-First with SQL Server  
- MediatR: CQRS pattern  
- Serilog: Structured logging  
- Swagger: API documentation  
- xUnit: Unit testing  
- JWT: Authentication & Authorization  
- Docker: Containerized API & SQL Server  
- GitHub Actions / Azure DevOps: CI/CD pipelines  

---

## ⚙️ Setup Instructions

### Prerequisites

- .NET 8 SDK  
- Docker  
- SQL Server (Docker or Local)  
- IDE (Visual Studio 2022+)  

### 🚢 Running with Docker

```bash
# Clone the repository
git clone https://github.com/your-org/hr-api-clean-architecture.git
cd hr-api-clean-architecture

# Build and start containers
docker-compose up --build
```

### Running Tests

```bash
dotnet test
```

---

## API Documentation

- Swagger UI: `https://localhost:5001/swagger`
- Versioned Endpoints:  
  - `api/v1/employees`  
  - `api/v1/reviews`  

### Sample Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/employees` | List all employees |
| POST | `/api/v1/employees` | Create an employee |
| PUT | `/api/v1/employees/{id}` | Update employee |
| DELETE | `/api/v1/employees/{id}` | Soft delete |
| GET | `/api/v1/analytics/summary` | Performance summary |

---

## Authentication & Authorization

- Uses **JWT Bearer Tokens**
- Role-based access control:
  - **Admin**: Full access
  - **Manager**: Limited to own team

You can get a token by hitting:  
`POST /api/v1/auth/login`

---

## Testing Strategy

- **xUnit** for unit tests  
- **EF Core InMemory** for integration tests  

Covers:
- Input validation  
- Edge cases  
- Auth logic  
- Controller → Mediator → Handler flow  

---

## CI/CD

- GitHub Actions or Azure DevOps Pipelines
- Steps:
  - Build → Test → Lint → Docker Build → Push → Deploy
- Secrets via GitHub/Azure Key Vault

---

## Assumptions & Design Decisions
 
- Soft delete strategy  
- JWT token lifespan: 1 hour (optional refresh support)  
- Static roles seeded via EF migrations  
- FluentValidation for models  
- Repository design pattern   
- Serilog for structured logs  
- Clean Architecture ensures scalability & testability  

