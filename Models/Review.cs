using System;
using System.Collections.Generic;

namespace hotel_management_API.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? RoomId { get; set; }

    public int? GuestId { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Room? Room { get; set; }
}
