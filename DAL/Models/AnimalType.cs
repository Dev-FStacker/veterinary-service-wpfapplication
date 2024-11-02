using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AnimalType
{
    public string TypeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AnimalProfile> AnimalProfiles { get; set; } = new List<AnimalProfile>();
}
