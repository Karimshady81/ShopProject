# 🏬 ShopProject  

A complete ASP.NET Core MVC web application built as part of **Gill Cleeren’s _ASP.NET Core 6 Fundamentals_** course on Pluralsight.  
This project demonstrates modern web development concepts using the MVC pattern, Entity Framework Core, and real-world features such as routing, model binding, validation, testing, interactivity, and authentication/authorization.

---

## 🧩 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Branches](#branches)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Database Setup](#database-setup)
- [How to Run](#how-to-run)
- [Testing](#testing)
- [Learnings](#learnings)
- [Future Improvements](#future-improvements)
- [License](#license)

---

## 🪄 Overview

This project was built step-by-step by following the **ASP.NET Core 6 Fundamentals** path.  
Each branch represents a different milestone from the course, starting with MVC basics and progressing toward a complete, functional web app with authentication.

---

## ✨ Features

- ASP.NET Core MVC architecture  
- Entity Framework Core with a real **SQL Server LocalDB** database  
- Routing and navigation  
- Razor views with model binding and validation  
- Forms with input validation (server + client)  
- Component testing using xUnit  
- Dynamic UI interactivity using partial views and scripts  
- Authentication and Authorization (Identity integration)  
- Clean folder structure and reusable components  

---

## 🌿 Branches

| Branch | Description |
|--------|--------------|
| **main** | Merged final version with all completed features |
| **feature/forms-model-binding** | Implements forms, input validation, and model binding |
| **feature/testing-components** | Adds unit tests and validation testing for controllers/components |
| **feature/make-site-interactive** | Adds dynamic interactivity with partial views and client-side logic |
| **feature/authentication-authorization** | Integrates ASP.NET Core Identity for login, registration, and role-based access |

Each branch isolates one core learning module to make it easy to explore the code step-by-step.

---

## 🧱 Tech Stack

- **.NET 8 / ASP.NET Core MVC**  
- **Entity Framework Core (SQL Server LocalDB)**  
- **Razor Pages & Tag Helpers**  
- **xUnit** (testing framework)  
- **Bootstrap / CSS / JS** for styling and interactivity  

---

## 📁 Architecture

```
ShopProject/
│
├── Controllers/         # Handles user requests and routing
├── Models/              # Domain models + EF Core entities
├── Views/               # Razor views (strongly typed)
├── wwwroot/             # Static assets (CSS, JS, images)
├── Data/                # EF Core DbContext and migrations
├── Migrations/          # Auto-generated EF migrations
├── ShopProjectTests/    # Unit tests for controllers and models
│
└── appsettings.json     # Connection string and configuration
```

---

## 🗄️ Database Setup

Make sure SQL Server LocalDB is installed.  
Then run the following commands in the terminal:

```bash
dotnet ef database update
```

This will create the required tables automatically based on your EF Core migrations.

Sample connection string (inside `appsettings.json`):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ShopProject;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

---

## ▶️ How to Run

Clone the repo and restore dependencies:

```bash
git clone https://github.com/Karimshady81/ShopProject.git
cd ShopProject
dotnet restore
dotnet run
```

Visit: **https://localhost:5001/** (or the port shown in the console)

---

## 🧪 Testing

Unit tests are located under `/ShopProjectTests`.

To execute tests:
```bash
dotnet test
```

Covers:
- Controller action results  
- Form validation  
- Database context interactions  

---

## 🧠 Learnings

This project reinforced key ASP.NET Core concepts including:
- MVC pattern and separation of concerns  
- Routing, Razor syntax, and Tag Helpers  
- Working with EF Core (DbContext, Migrations, LINQ)  
- Model validation (Data Annotations + server/client side)  
- Authentication and Authorization via Identity  
- Writing and running automated tests  
- Managing feature branches with Git and GitHub  

---

## 🚀 Future Improvements

- Add pagination, filtering, and sorting  
- Introduce repository/service layers for cleaner architecture  
- Improve UI design using Bootstrap 5  
- Deploy on Azure or Render  
- Add CI/CD pipeline (GitHub Actions)  

---

## 📜 License
This project is open for educational purposes.  
Feel free to fork or clone for learning, practice, or portfolio use.
