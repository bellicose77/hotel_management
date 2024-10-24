namespace hotel_management_API.Models.DTO
{
    public class BookingDto
    {
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public string RoomType { get; set; }
        public string userEmail { get; set; }
    }
}
