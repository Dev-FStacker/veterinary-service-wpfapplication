using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ServiceDeliveryMethod
{
    public string ServiceDeliveryMethodId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
