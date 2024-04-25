using System;
using System.Collections.Generic;

namespace SnapChatUserApi.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public Guid? SegmentId { get; set; }

    public virtual Segment? Segment { get; set; }
}
