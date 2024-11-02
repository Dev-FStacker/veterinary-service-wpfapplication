using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Service
{
    public string ServiceId { get; set; } = null!;

    public string ServiceDeliveryMethodId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual ServiceDeliveryMethod ServiceDeliveryMethod { get; set; } = null!;
}
