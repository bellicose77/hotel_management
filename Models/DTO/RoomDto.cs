namespace hotel_management_API.Models.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; } = null!;

        public string RoomType { get; set; } = null!;

        public int Capacity { get; set; }

        public decimal PricePerNight { get; set; }

        public string Status { get; set; } = null!;
    }
}
