# MVC.NetMinyaITISummer2026AugustD04

# 🔷 ASP.NET Core MVC – CRUD with Entity Framework Core (.NET 9)

This project demonstrates **ASP.NET Core MVC CRUD operations** for Employees and Departments with:

- ✅ Entity Framework Core
- ✅ ViewModels (VM)
- ✅ Custom Validation Attributes
- ✅ Server & Client Side Validation
- ✅ Bootstrap Modals for Delete Confirmation
- ✅ Data Mapping between Domain Models & ViewModels

---

## 📁 Project Structure

```
ASP.NETCoreD04
│
├── Controllers
│   ├── DepartmentController.cs
│   └── EmployeeController.cs
│
├── Models
│   ├── Department.cs
│   └── Employee.cs
│
├── ViewModels
│   ├── Department
│   │   ├── DepartmentCreateVM.cs
│   │   ├── DepartmentEditVM.cs
│   │   └── DepartmentReadVM.cs
│   └── Employee
│       ├── EmployeeCreateVM.cs
│       ├── EmployeeEditVM.cs
│       └── EmployeeReadVM.cs
│
└── Data
    └── Context
        └── AppDbContext
```

---

## 📌 Domain Models

### Employee

```csharp
public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }

    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; } = null!;
}
```

### Department

```csharp
public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
```

---

## 📌 Employee ViewModel (Create Example)

```csharp
public class EmployeeCreateVM
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Range(18, 50, ErrorMessage = "Range 18 ~ 50")]
    public int Age { get; set; }

    [Required]
    [Range(2000, 5000)]
    public decimal Salary { get; set; }

    [Required]
    [StringLength(256, MinimumLength = 12)]
    public string? Address { get; set; }

    [Required]
    [EmailAddress]
    [Remote(action:"IsEmailAvailabe", controller:"Employee", ErrorMessage = "Email Alreay Exist")] // Remote Validation
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

    [DisplayName("Department")]
    public int DepartmentId { get; set; }

    public List<SelectListItem>? Departments { get; set; }
}
```

---

## 📌 DepartmentController (CRUD)

- Index → List all Departments
- Details → Show Department details
- Create → Add new Department
- Edit → Update Department
- Delete → Remove Department

```csharp
public IActionResult Index()
{
    var departmentsReadVM = db.Departments.Select(d => new DepartmentReadVM
    {
        Id = d.Id,
        Name = d.Name
    });
    return View(departmentsReadVM);
}
```

---

## 📌 EmployeeController (CRUD)

- Index → List all Employees with Department
- Details → Show Employee details
- CreateV01 / CreateV02 → Add Employee (Direct or via VM)
- Edit → Update Employee
- Delete → Remove Employee
- `IsEmailAvailable` → Remote server-side email validation

---

## 📌 Views

- **Department Views:** Index, Create, Edit, Details
- **Employee Views:** Index, CreateV01, CreateV02, Edit, Details
- **Delete Modal:** Bootstrap modal for confirmation
- **Validation Scripts:** jQuery unobtrusive validation for client-side checks

---

## 📌 Helper Methods

- GetDepartmentsForDropDown() → Populates dropdown list for Employee forms
- DRY principle applied

```csharp
private List<SelectListItem> GetDepartmentsForDropDown()
{
    return db.Departments.Select(d => new SelectListItem
    {
        Value = d.Id.ToString(),
        Text = d.Name
    }).ToList();
}
```

---

## 📌 Key Features

- ViewModel separation (VM → UI)
- Server & Client-side validation
- Remote validation for Email
- Bootstrap modals for delete confirmation
- Eager loading using `.Include(e => e.Department)`

---

## ▶ How to Run

1️⃣ Update SQL Server connection string in `AppDbContext`.  
2️⃣ Run `Add-Migration InitialCreate` & `Update-Database`.  
3️⃣ Launch project in Visual Studio (F5) or `dotnet run`.  

---

## 🔹 Learning Outcomes

- CRUD with ASP.NET Core MVC
- EF Core One-to-Many relationship
- Data validation & custom attributes
- ViewModels & form binding
- Bootstrap & jQuery integration

---

# 👨‍💻 Author

Mohamed Hatem  
Software Engineer

---