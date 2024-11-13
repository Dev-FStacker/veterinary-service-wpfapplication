using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Account
{
    public string AccountId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public string? Avatar { get; set; }

    public string Password { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Role Role { get; set; } = null!;
    
    public string GetRoleName
    {
        get
        {
            if (RoleId == "R0" || RoleId == "R1" || RoleId == "R2") return "Admin";
            if (RoleId == "R3") return "Veterinarian";
            return "Customer";

        }
    }
}
