# 🚗 AUTO B&T Vehicle Service Management System

A comprehensive desktop application for managing vehicle service operations, built with .NET 9 and Entity Framework Core.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-0078D4?style=flat&logo=windows)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%209.0-512BD4?style=flat)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=flat&logo=microsoft-sql-server)](https://www.microsoft.com/en-us/sql-server)

---

## ✨ Features

### 👤 Customer Management
- Complete CRUD operations for customer records
- Contact information management (phone, email, address)
- Customer search and filtering
- View customer service history

### 🚗 Vehicle Management
- Register and manage vehicle information
- Track make, model, year, VIN, registration number
- Link vehicles to customers
- Monitor service history per vehicle
- OBD-II error code tracking

### 🔧 Service Order Management
- Create and manage service orders
- Add multiple parts to service orders
- Automatic inventory deduction
- Labor cost and parts cost tracking
- Service status tracking (Pending, In Progress, Completed)
- Payment status management (Unpaid, Partial, Paid)

### 📄 Invoice Generation
- Professional PDF generation using QuestPDF
- Print preview and print-to-printer functionality
- Automatic invoice numbering
- Itemized parts and labor breakdown
- Save to organized folder structure (Documents/AUTO_B&T_Invoices)

### 📊 Comprehensive Reporting
- Monthly Revenue Report with aggregated data
- Customer Service History with spending analysis
- Low Stock Alerts for inventory management
- Top Customers Report by revenue
- Export to PDF and CSV for all reports
- Date range filtering and search

### 🔍 Advanced Search & Filtering
- Real-time search across invoices
- Multi-field search (customer name, invoice number, vehicle)
- Date range filtering
- Status-based filtering
- Column sorting in all data grids

### 💾 Database Backup & Restore
- One-click database backup
- Timestamped backup files
- Database restoration from backup
- Stored in Documents/AUTO_B&T_Backups

### 📱 Additional Features
- Help/About page with system information
- Modern metro-style UI with color-coded navigation
- Input validation with user-friendly error messages
- Error handling throughout the application

---

## 🛠️ Technologies Used

### Core Framework
- **.NET 9.0** - Latest .NET framework
- **C# 13.0** - Modern C# language features
- **Windows Forms** - Desktop UI framework

### Database & ORM
- **Entity Framework Core 9.0** - Object-Relational Mapper
- **SQL Server LocalDB** - Lightweight development database
- **LINQ** - Language Integrated Query for data operations

### Libraries & Packages
- **QuestPDF** - Professional PDF document generation
- **System.Drawing.Common** - Graphics and printing support
- **Microsoft.EntityFrameworkCore.SqlServer** - SQL Server provider
- **Microsoft.EntityFrameworkCore.Tools** - EF Core migration tools

### Design Patterns & Concepts
- Repository Pattern (DbContext)
- Model-View Pattern
- Factory Pattern (Document generation)
- Observer Pattern (Event-driven programming)
- One-to-Many and Many-to-Many relationships
- LINQ queries and aggregations
- Lambda expressions

---

## 💻 Installation

### Prerequisites
- Visual Studio 2022 (or later)
- .NET 9.0 SDK
- SQL Server LocalDB (included with Visual Studio)
- QuestPDF
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualBasic
- System.Data.SqlClient
- WinForms.DataVisualization

### Steps
1. Clone the repository (git clone https://github.com/killerbee-b/VehicleServiceManager.git)
2. Open `VehicleServiceManager.sln` in Visual Studio
3. Restore NuGet packages (automatic)
4. Build and run (F5)
5. Database will be created automatically on first run

---

## 🏆 Key Highlights

✅ **Professional Architecture** - Clean separation of concerns (Presentation, Business Logic, Data Access)

✅ **Advanced Database Design** - 7 related entities with proper relationships and foreign key constraints

✅ **Modern ORM Usage** - Entity Framework Core 9.0 with LINQ queries and eager loading

✅ **Comprehensive CRUD Operations** - Full Create, Read, Update, Delete functionality for all entities

✅ **Business Intelligence** - Revenue analytics, customer reports, inventory alerts, and top customers ranking

✅ **Document Generation** - Professional PDF invoices and reports with QuestPDF, plus print functionality

✅ **User Experience** - Metro-style modern UI with real-time search, filtering, and smooth navigation

✅ **Data Safety** - Database backup/restore, transaction management, and referential integrity

---

## 📚 Learning Outcomes

This project demonstrates proficiency in:
- Object-Oriented Programming (OOP)
- Entity Framework Core and ORMs
- Database design and relationships
- LINQ and Lambda expressions
- Windows Forms event-driven programming
- File I/O operations
- PDF generation libraries
- Software architecture patterns
- Error handling and validation
- User interface design

---

## 📝 License

This project is created for educational purposes as part of the Visual Programming course.

---

## 👨‍💻 Author

**Berk Saliu & Tarik Emrulahi**

Visual Programming Project 2025  
International Balkan University (IBU)

---

**⭐ If you found this project helpful, please give it a star!**
