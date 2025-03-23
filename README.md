# 🚀 Tez Services API

A **.NET 7 Web API** for managing users, organizations, and JWT-based authentication. This project demonstrates secure authentication, role-based authorization, and follows a clean architecture with Repository and Service layers.

---

## 📂 Project Structure
/TEZ ├── Controllers/ ├── DbContext/ ├── Models/ ├── Repositories/ ├── Services/ └── Program.cs


---

## 🛠️ Tech Stack

- .NET 7 / ASP.NET Core Web API
- Entity Framework Core (PostgreSQL)
- JWT Authentication
- Swagger (OpenAPI) for API documentation

---

## 🚧 Features

- ✅ JWT Authentication & Authorization
- ✅ Role-based Access Control
- ✅ User Management (CRUD)
- ✅ Organization Management (CRUD)
- ✅ Secure Password Hashing with BCrypt
- ✅ TPT Inheritance in EF Core
- ✅ Clean Architecture (Repository + Service Pattern)
- ✅ API Documentation with Swagger

---

## 📦 Setup Instructions

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/)
- (Optional) [Docker](https://www.docker.com/)

---

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/tezservices-api.git
cd tezservices-api

```
### 2. Application Settings
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=tezdb;Username=postgres;Password=yourpassword"
  },
  "Jwt": {
    "Key": "your-secure-jwt-key",
    "Issuer": "TezServices"
  }
}

### 3. Run migrations and update database
```bash
dotnet ef database update
```

### 4. Run the project
```bash
dotnet clean
dotnet restore
dotnet build
dotnet run
```


