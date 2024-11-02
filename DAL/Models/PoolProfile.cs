using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PoolProfile
{
    public string PoolProfileId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string BookingDetailId { get; set; } = null!;

    public string? Note { get; set; }

    public double Width { get; set; }

    public string? Description { get; set; }

    public double Height { get; set; }

    public double Depth { get; set; }

    public string? Picture { get; set; }

    public virtual BookingDetail BookingDetail { get; set; } = null!;
}
