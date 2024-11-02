using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public int ServiceRating { get; set; }

    public int VetRating { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
