# 🚗 Car Wash Management System

## Project Overview

This is a robust, feature-complete management system designed to handle the daily operations and administrative reporting for a car wash business. The system is built using C\# and Windows Forms, focusing on a clear, role-based user interface and secure data management.

### Key Features Implemented:

  * **Secure User Authentication:** Login with user roles, and account lockout after 3 failed attempts.
  * **Role-Based Access:** Distinct functionality and dashboard views for `ADMIN` and `RECORDER` roles.
  * **Transaction Management:** Full CRUD (Create, Read, Update, Delete) capability for recording customer washes, services, vehicle types, and payment status.
  * **Vehicle & Services Management:** Admin panels to manage available services and vehicle types.
  * **Expense Management:** Dedicated module for tracking monthly business expenses.
  * **Automated Reporting:** Calculation and display of real-time daily stats and comprehensive monthly/yearly financial reports (Revenue, Expenses, Net Profit, Employee Share, Most Popular Services/Vehicles, etc.).
  * **Auditing:** System logging of all critical actions (login, logout, user creation/status changes, CRUD operations).

-----

## 🛠️ Technology Stack

  * **Language:** C\#
  * **Framework:** .NET (Windows Forms)
  * **Architecture:** Layered (UI, Core.Managers, Core.FileHandlers, Core.Enums)
  * **Data Storage:** Local flat files (.txt, .log) storing structured text and logs for persistence.

-----

## 🚀 Getting Started

### Prerequisites

  * **Visual Studio 2022** (with the **.NET desktop development** workload installed).
  * **Windows Operating System** (Required for Windows Forms application).

### Installation and Setup

1.  **Clone the Repository (if hosted):**

    ```bash
    git clone https://github.com/miccael-jaspertayas/CarWashManagementSystem
    ```

    *(If not hosted, simply open the project folder in Visual Studio.)*

2.  **Open the Solution:**
    Open the `CarWashManagement.sln` file in Visual Studio.

3.  **Run the Application:**
    Ensure the `CarWashManagement.UI` project is set as the startup project. Press **F5** to build and run the system.

### Initial Credentials

The system automatically initializes the default administrative account if no user data files are found.

| Username | Password | Role |
| :---: | :---: | :---: |
| **admin** | **admin123** | ADMIN |

-----

## 📂 System File Structure

The system uses flat text files stored in a dedicated Application Data folder (AppData) for all persistent data. This ensures that user and business records are kept separate from the executable, following Windows best practices for application storage.

By default, files are saved under the user’s profile directory:
'C:\Users\<Username>\AppData\Roaming\CarWashManagementSystem\'

| File | Purpose | Manager |
| :--- | :--- | :--- |
| `users.txt` | Stores all user accounts, roles, statuses, passwords, and number of failed login attempts. | `AccountManager` |
| `transactions.txt` | Stores all records of completed and ongoing car wash services. | `TransactionManager` |
| `expenses.txt` | Stores all financial expenditures/business costs. | `ExpenseManager` |
| `services.txt` | Stores the list of available services and their prices. | `CarManager` |
| `vehicles.txt` | Stores the list of available vehicle types and base wash prices. | `CarManager` |
| `audit.txt` | Logs all critical actions (logins, password changes, user status changes). | `AuditFileHandler` |

-----

## 👤 User Roles and Permissions

| Role | Dashboard Access | Admin Menu Access | Key Capabilities |
| :---: | :--- | :--- | :--- |
| **ADMIN** | Full | All management forms (Users, Vehicles, Services, Expenses) and Reporting. | Can activate/deactivate users, set prices, and access all financial reports. |
| **RECORDER** | Full | None (Restricted to daily operations). | Create new transactions, update transaction status, and update own password. |

-----

## 📊 Reporting Logic

The Monthly/Yearly Report feature provides essential business intelligence:

  * **Net Profit:** Calculated as **Total Owner Share** - **Total Expenses**.
  * **Revenue Shares:** All transaction amounts are split between **Owner Share** and **Employee Share** based on rules defined in the `TransactionManager`.
  * **Historical Data:** All calculations are performed against **"Paid"** transactions only within the selected time range.
