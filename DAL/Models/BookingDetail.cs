using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class BookingDetail
{
    public string BookingDetailId { get; set; } = null!;

    public string BookingId { get; set; } = null!;

    public string ServiceId { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public bool Incidental { get; set; }

    public string? NoteResult { get; set; }

    public string? AnimalStatusDescription { get; set; }

    public string? ConsultDoctor { get; set; }

    public string? DrugList { get; set; }

    public string? PoolStatusDescription { get; set; }

    public string? ConsultTechnician { get; set; }

    public string? MaterialList { get; set; }

    public virtual ICollection<AnimalProfile> AnimalProfiles { get; set; } = new List<AnimalProfile>();

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<PoolProfile> PoolProfiles { get; set; } = new List<PoolProfile>();

    public virtual Service Service { get; set; } = null!;
}
