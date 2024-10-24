using System;
using System.Collections.Generic;

namespace hotel_management_API.Models;

public partial class Room
{
    public int Id { get; set; }

    public string RoomType { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal PricePerNight { get; set; }

    public string Description { get; set; }
    public string Image { get; set; }
}
