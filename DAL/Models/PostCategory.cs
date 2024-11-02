using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PostCategory
{
    public string PostCategoryId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
