using System;
using System.Collections.Generic;

namespace SnapChatUserApi.Models;

public partial class Segment
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
