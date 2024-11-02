using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? AccountId { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public bool? Sex { get; set; }

    public DateOnly? Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Account? Account { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
