using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AnimalProfile
{
    public string AnimalProfileId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public string BookingDetailId { get; set; } = null!;

    public double Size { get; set; }

    public int Age { get; set; }

    public string Color { get; set; } = null!;

    public string? Description { get; set; }

    public bool Sex { get; set; }

    public string? Picture { get; set; }

    public virtual BookingDetail BookingDetail { get; set; } = null!;

    public virtual AnimalType Type { get; set; } = null!;
}
