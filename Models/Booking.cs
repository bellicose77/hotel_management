using System;
using System.Collections.Generic;

namespace hotel_management_API.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? RoomId { get; set; }

    public int? GuestId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public string? BookingStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? Room { get; set; }

    public virtual ICollection<Roomservice> Roomservices { get; set; } = new List<Roomservice>();
}
