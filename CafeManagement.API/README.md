# ☕ Coffee House Management System

A full-stack coffee house management system built with **ASP.NET Core Web API** and **Vanilla JavaScript**.

The system provides a complete solution for managing a coffee house, including menu items, categories, tables, reservations, orders, payments, users, and administrative operations.

## 🌐 Live Demo

**[Visit Coffee House Management System](https://cafemanagementsystem.runasp.net/)**

---

## ✨ Features

### 👤 Authentication & Authorization

* User registration and login
* JWT authentication
* Role-based authorization
* Admin and Customer roles
* ASP.NET Core Identity

### ☕ Menu Management

* Manage menu categories
* Create, update, and delete menu items
* Manage item prices
* Manage item availability
* Product images
* Out-of-stock management

### 🪑 Table & Reservation Management

* View available tables
* Different table capacities
* Create table reservations
* Manage reservation status
* Admin reservation management

### 🛒 Order Management

* Create customer orders
* Dine-in and takeaway orders
* Manage order items
* Calculate order totals
* Update order status
* Admin order management

### 💳 Payment Management

* Payment simulation
* Cash and card payment methods
* Payment status tracking
* Admin payment management

### 👨‍💼 Admin Dashboard

The admin can manage:

* Categories
* Menu Items
* Tables
* Reservations
* Orders
* Payments

---

## 🛠️ Tech Stack

### Backend

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **ASP.NET Core Identity**
* **JWT Authentication**
* **AutoMapper**
* **FluentValidation**
* **Swagger / OpenAPI**

### Frontend

* **HTML5**
* **CSS3**
* **Vanilla JavaScript**
* **Fetch API**

### Architecture & Patterns

* Clean Architecture principles
* Repository Pattern
* Service Layer
* DTO Pattern
* Entity Framework Core Code First
* Dependency Injection

### Tools

* Visual Studio
* SQL Server Management Studio
* Git
* GitHub

---

## 🏗️ Project Structure

```text
CoffeeHouseManagementSystem
│
├── CafeManagement.API
│   ├── Controllers
│   ├── wwwroot
│   │   ├── css
│   │   ├── js
│   │   └── HTML Pages
│   ├── Program.cs
│   └── appsettings.json
│
├── CafeManagement.Core
│   ├── DTOs
│   ├── Entities
│   ├── Enums
│   └── Interfaces
│
└── CafeManagement.Infrastructure
    ├── Data
    ├── Identity
    ├── Migrations
    ├── Repositories
    └── Services
```

---

## 🔐 Security

The application uses:

* JWT-based authentication
* ASP.NET Core Identity
* Role-based authorization
* Secure configuration
* Environment-based secrets

> Sensitive credentials are excluded from the public repository.

---

## 📚 API Documentation

The backend API is documented using **Swagger / OpenAPI**, allowing developers to explore and test the available API endpoints.

---

## 🚀 Getting Started

### Prerequisites

Make sure you have:

* .NET SDK installed
* SQL Server
* Visual Studio or another compatible IDE

### Clone the Repository

```bash
git clone https://github.com/OmniaShazli/CoffeeHouseManagementSystem.git
```

### Configure the Database

Configure your SQL Server connection string in your local environment.

### Configure JWT

Configure the JWT settings using environment variables or local development configuration.

### Apply Database Migrations

```bash
dotnet ef database update
```

### Run the Application

```bash
dotnet run
```

Then open the application in your browser.

---

## 🎯 Project Goals

This project was developed to practice and demonstrate:

* RESTful API development
* Backend architecture
* Database design
* Entity Framework Core
* Authentication and authorization
* Repository and service patterns
* Frontend-backend integration
* CRUD operations
* Real-world business workflows
* Git and GitHub workflow

---

## 👩‍💻 Author

### Omnia Shazli

Computer Science Student | .NET Developer

Interested in **Backend Development, ASP.NET Core, Software Engineering, AI & Machine Learning**.

**GitHub:** [OmniaShazli](https://github.com/OmniaShazli)

---

⭐ If you find this project useful or interesting, feel free to star the repository!
