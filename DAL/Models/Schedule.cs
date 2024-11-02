using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Schedule
{
    public string ScheduleId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string? Note { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<SlotTable> SlotTables { get; set; } = new List<SlotTable>();
}
