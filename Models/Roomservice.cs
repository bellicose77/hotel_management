using System;
using System.Collections.Generic;

namespace hotel_management_API.Models;

public partial class Roomservice
{
    public int ServiceId { get; set; }

    public int? BookingId { get; set; }

    public string Description { get; set; } = null!;

    public decimal ServiceCharge { get; set; }

    public DateTime? ServiceDate { get; set; }

    public virtual Booking? Booking { get; set; }
}
