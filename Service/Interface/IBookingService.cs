using hotel_management_API.Models;
using hotel_management_API.Models.DTO;

namespace hotel_management_API.Service.Interface
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync(string userId);
        Task<Booking> CreateBookingAsync(BookingDto bookingDto);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
    }
}
