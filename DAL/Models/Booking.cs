using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string? EmployeeId { get; set; }

    public DateTime BookingDate { get; set; }

    public DateTime ExpiredDate { get; set; }

    public decimal Deposit { get; set; }

    public int NumberOfFish { get; set; }

    public int IncidentalFish { get; set; }

    public int NumberOfPool { get; set; }

    public int IncidentalPool { get; set; }

    public string ServiceDeliveryMethodId { get; set; } = null!;

    public double? Vat { get; set; }

    public string BookingAddress { get; set; } = null!;

    public double Distance { get; set; }

    public decimal DistanceCost { get; set; }

    public decimal TotalServiceCost { get; set; }

    public string Status { get; set; } = null!;

    public string FeedbackId { get; set; } = null!;

    public string ScheduleId { get; set; } = null!;

    public string? Note { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Feedback Feedback { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual ServiceDeliveryMethod ServiceDeliveryMethod { get; set; } = null!;
}
