using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class SlotTable
{
    public string SlotTableId { get; set; } = null!;

    public string ScheduleId { get; set; } = null!;

    public string? Note { get; set; }

    public int? Slot { get; set; }

    public int? SlotCapacity { get; set; }

    public int? SlotOrdered { get; set; }

    public bool SlotStatus { get; set; }

    public Schedule Schedule { get; set; } = null!;
}
