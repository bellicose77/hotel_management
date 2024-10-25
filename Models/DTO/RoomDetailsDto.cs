namespace hotel_management_API.Models.DTO
{
    public class RoomDetailsDto
    {
        public string RoomType { get; set; } = null!;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = null!;
        public bool Wifi {  get; set; }
        public bool AirConditioning { get; set; }
        public string Tv { get; set; }
        public string RoomService { get; set; }
        public bool Laundry { get; set; }
        public bool CoffeeMaker { get; set; }
        public int Bed { get; set; }

        public string Image { get; set; }
    }
}
