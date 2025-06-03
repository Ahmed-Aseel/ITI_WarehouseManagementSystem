# 📦 Warehouse Management System

## 📋 Description

A desktop warehouse management system built with **C#** and **Windows Forms** for a trading company that owns multiple warehouses and needs efficient tracking of inventory, suppliers, customers, and operations.

The system allows you to manage:

* 🏬 **Warehouses**: name, address
* 📦 **Items**: code, name, unit of measure
* 👤 **Suppliers & Customers**: name, phone, fax, mobile, email, website
* 📥 **Supply Permissions**: track incoming stock with item details, supplier, production and expiry dates
* 📤 **Release Permissions**: record outgoing stock with item quantities and customer
* 🔄 **Transfer Permissions**: move items between warehouses with tracking
* 📊 **Reports**:

  * Warehouse contents by period
  * Item stock status per warehouse
  * Item movement history
  * Items with prolonged inactivity
  * Items nearing expiry

---

## 🧰 Technologies Used

* C# Windows Forms
* .NET Framework / .NET Core
* Entity Framework (Code First)
* SQL Server (LocalDB)
* LINQ

---

## ▶️ How to Use

### 1. **Clone the Repository**

```bash
git clone https://github.com/YourUsername/Warehouse-Management-System.git
```

### 2. **Open the Project**

* Open the `.sln` file in **Visual Studio**.

### 3. **Configure the Database**

* Check the `WarehouseContext` class in `Data/Contexts`.
* Ensure your connection string in `app.config` or `appsettings.json` points to a valid **LocalDB SQL Server** instance.
* Example connection string:

  ```
  "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WarehouseDB;Integrated Security=True;"
  ```

### 4. **Apply Migrations (if not yet applied)**

* Use Package Manager Console:

  ```bash
  Add-Migration InitialCreate
  Update-Database
  ```

### 5. **Run the Application**

* Press `F5` or click `Start` in Visual Studio to launch the system.

---

## 🧚 Features Overview

| Feature                  | Description                                     |
| ------------------------ | ----------------------------------------------- |
| **Warehouse Management** | Add/edit warehouses with addresses              |
| **Inventory Items**      | Create item records (code, name, unit)          |
| **Supply/Release**       | Manage incoming/outgoing inventory              |
| **Transfers**            | Move items between warehouses                   |
| **Reports**              | Generate detailed reports on stock and movement |

---

## 📝 Notes

* Multi-warehouse selections allow filtering and comparative reporting.
* Reports support custom date ranges and conditions.
* All data updates are reflected in real-time from the database.

---

## 📢 Contact

For bugs, questions, or contributions, feel free to open an issue or reach out.
