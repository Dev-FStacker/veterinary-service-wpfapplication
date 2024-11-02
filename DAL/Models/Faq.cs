using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Faq
{
    public string FaqId { get; set; } = null!;

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;
}
