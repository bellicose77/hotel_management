namespace hotel_management_API.Models.DTO
{
    public class BookingDetailsDto
    {
        public string? GuestName {  get; set; }
        public string? GuestEmail {  get; set; }
        public string? GuestPhone { get; set; }
        public int? RoomNumber {  get; set; }
        public string? RoomType { get; set; }
        public DateOnly? CheckinDate {  get; set; }
        public DateOnly? CheckoutDate { get;  set; }
        public DateTime? BookingDate { get; set; }
    }
}
