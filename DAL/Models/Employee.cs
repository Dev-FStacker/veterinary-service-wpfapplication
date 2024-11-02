using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string? AccountId { get; set; }

    public string RoleId { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool? Sex { get; set; }

    public DateOnly? Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Account? Account { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
