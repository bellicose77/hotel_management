using hotel_management_API.Service.Service;
using System;

namespace hotel_management_API.Models;

public partial class RoomDetails
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public bool Wifi { get; set; }
    public bool AirConditioning { get; set; }
    public string Tv { get; set; }
    public string RoomService { get; set; }
    public bool Laundry { get; set; }
    public bool CoffeeMaker { get; set; }
    public int Bed { get; set; }
}
