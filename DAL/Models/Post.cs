using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Post
{
    public string PostId { get; set; } = null!;

    public string PostName { get; set; } = null!;

    public string PostCategoryId { get; set; } = null!;

    public string Context { get; set; } = null!;

    public virtual PostCategory PostCategory { get; set; } = null!;
}
