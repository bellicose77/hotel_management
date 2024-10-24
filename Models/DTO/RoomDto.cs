namespace hotel_management_API.Models.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }

        public string RoomType { get; set; } = null!;

        public int Capacity { get; set; }

        public decimal PricePerNight { get; set; }

        public string Description { get; set; } = null!;

        public string Image { get; set; }
    }
}
