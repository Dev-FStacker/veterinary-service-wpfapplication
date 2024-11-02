using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string Rolename { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
