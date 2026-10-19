# 🎬 Quiet Attic Films — Production Management System

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/Database-MS%20SQL%20Server-CC292B.svg)](https://www.microsoft.com/sql-server)
[![UI](https://img.shields.io/badge/GUI-Windows%20Forms-512BD4.svg)]()
[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6.svg)]()
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A desktop-based enterprise management system developed for **Quiet Attic Films**, a film production company. This application streamlines production operations, crew management, property and asset tracking, shooting location scheduling, client orders, and billing workflows.

---

## 📌 Table of Contents
- [About the Project](#-about-the-project)
- [Key Features](#-key-features)
  - [Role-Based Access](#-role-based-access)
  - [Administrator Capabilities](#-administrator-capabilities)
  - [Staff / Employee Capabilities](#-staff--employee-capabilities)
- [Tech Stack](#-tech-stack)
- [System Architecture & Modules](#-system-architecture--modules)
- [Prerequisites](#-prerequisites)
- [Database Setup](#-database-setup)
- [Installation & How to Run](#-installation--how-to-run)
- [Configuration](#-configuration)
- [Project Structure](#-project-structure)
- [Contributing](#-contributing)
- [License](#-license)

---

## 📖 About the Project

**Quiet Attic Films** manages multiple concurrent film productions involving numerous clients, crew members, properties, equipment, and shooting locations. This software provides a centralized desktop solution to track:
- Film production schedules and order processing.
- Client registrations and invoicing/payments.
- Crew allocations across film projects.
- Props, equipment, and shooting location availability.

Built using **C# Windows Forms** and **Microsoft SQL Server**, the application provides high performance, reliable transaction handling, and an intuitive user interface.

---

## ✨ Key Features

### 🔐 Role-Based Access
- **Loading / Splash Screen**: Animated introductory loading screen.
- **Role Selector**: Quick gateway to switch between **Admin** and **Staff (Employee)** portals.
- **Secure Authentication**: Dedicated login screens with validation for Admins and Employees.

### 👑 Administrator Capabilities
Full administrative privilege over company operations:
- **Admin Management (`FormAdmin`)**: Add, update, and manage system administrator profiles.
- **Employee Management (`FormEmp`)**: Maintain employee records, credentials, and roles.
- **Crew Management (`FormCrew`)**: Organize production crew members, their specializations, and assignments.
- **Client Management (`FormCustomer`)**: Register and maintain corporate/individual client records.
- **Film Order Management (`FormOrder`)**: Create, monitor, and update production booking orders.
- **Production Management (`FormProduction`)**: Track ongoing film productions, milestones, and deliverables.
- **Property & Equipment Tracking (`FormProperty`)**: Manage film props, camera gear, and studio equipment.
- **Location Management (`FormLocation`)**: Manage outdoor and indoor shooting sites and bookings.
- **Payment & Invoicing (`FormPayment`)**: Record client transactions, compute totals, and verify payment status.

### 💼 Staff / Employee Capabilities
Streamlined portal for daily operational duties:
- **Customer Portal (`EmpCus`)**: Search, register, and update client information.
- **Order Processing (`EmpOder`)**: Process incoming production orders and requirements.
- **Payment Logging (`EmpPay`)**: Record customer payments and generate receipts.

---

## 🛠️ Tech Stack

- **Programming Language**: C#
- **Framework**: .NET Framework 4.8
- **UI Technology**: Windows Forms (WinForms)
- **Database**: Microsoft SQL Server (MSSQL / SQL Express)
- **Data Access Layer**: ADO.NET / Typed DataSets (`SqlClient`)
- **IDE**: Microsoft Visual Studio 2022 / 2019

---

## 🗄️ Database Setup

The project includes a ready-to-restore database backup file:  
📁 `Quite_Attic_Films_Version_5.bak`

### Steps to Restore the Database:
1. Open **SQL Server Management Studio (SSMS)** and connect to your SQL Server instance (e.g., `.\SQLEXPRESS` or `(localdb)\MSSQLLocalDB`).
2. In Object Explorer, right-click on **Databases** and select **Restore Database...**
3. Select **Device** -> click `...` -> click **Add** and browse to `Quite_Attic_Films_Version_5.bak`.
4. Set the Database name to:
   ```text
   Quite_Attic_Films_Version_5
   ```
5. Click **OK** to restore.

---

## ⚙️ Configuration

Ensure your database connection string in `Quiet Attic Films/App.config` matches your local SQL Server instance:

```xml
<connectionStrings>
    <add name="Quiet_Attic_Films.Properties.Settings.Quite_Attic_Films_Version_1ConnectionString"
        connectionString="Data Source=YOUR_SERVER_NAME\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
        providerName="System.Data.SqlClient" />
</connectionStrings>
```

> **Note**: Replace `YOUR_SERVER_NAME\SQLEXPRESS` with your local SQL instance name (e.g. `.\SQLEXPRESS` or `localhost`).

---

## 🚀 Installation & How to Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Pasan-Pramuditha/Quiet-Attic-Film-System-.git
   cd Quiet-Attic-Film-System-
   ```

2. **Restore Database**: Follow the [Database Setup](#-database-setup) instructions above.

3. **Open Project**:
   - Double click `Quiet Attic Films.sln` to open it in **Visual Studio 2022 / 2019**.

4. **Verify References & Connection**:
   - Check `App.config` connection strings.
   - Build the solution (`Ctrl + Shift + B`).

5. **Run the Application**:
   - Press `F5` or click **Start** in Visual Studio.

---

## 📂 Project Structure

```text
Quiet-Attic-Film-System-/
├── .gitignore                          # Git ignore rules for .NET / Visual Studio
├── README.md                           # Project documentation
├── Quite_Attic_Films_Version_5.bak     # SQL Server database backup
├── Quiet Attic Films.sln               # Visual Studio Solution file
└── Quiet Attic Films/                  # Main Project Directory
    ├── App.config                      # Application and database configuration
    ├── Program.cs                      # Main application entry point
    ├── LoadingForm.cs                  # Initial splash screen
    ├── SelectAdEmp.cs                  # Role selection screen
    ├── AdminLogin.cs                   # Administrator login form
    ├── LoginForm.cs                    # Employee login form
    ├── AdminForm.cs                    # Administrator dashboard
    ├── EmployeeForm.cs                 # Employee dashboard
    ├── FormAdmin.cs                    # Admin user management
    ├── FormCrew.cs                     # Crew management module
    ├── FormCustomer.cs                 # Customer management module
    ├── FormEmp.cs                      # Staff management module
    ├── FormLocation.cs                 # Shooting location management
    ├── FormOrder.cs                    # Film order processing
    ├── FormPayment.cs                  # Invoicing & payments
    ├── FormProduction.cs               # Production management
    ├── FormProperty.cs                 # Equipment and props tracking
    ├── EmpCus.cs                       # Employee customer handling
    ├── EmpOder.cs                      # Employee order handling
    ├── EmpPay.cs                       # Employee payment logging
    └── Resources/                      # UI icons and graphic assets
```

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!
1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.

---

## 👤 Author

- **Pasan Pramuditha**
- GitHub: [@Pasan-Pramuditha](https://github.com/Pasan-Pramuditha)
