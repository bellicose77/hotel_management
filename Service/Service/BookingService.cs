using hotel_management_API.Models;
using hotel_management_API.Models.DTO;
using hotel_management_API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_API.Service.Service
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBookingAsync(BookingDto bookingDto)
        {
            try
            {
                int roomId = _context.Rooms
                    .Where(e => e.RoomType == bookingDto.RoomType) 
                    .Select(e => e.Id)                             
                    .FirstOrDefault();

                int guestId = _context.Users
                    .Where(e => e.Email == bookingDto.userEmail)
                    .Select(e => e.Id)
                    .FirstOrDefault();
                
                Booking booking = new Booking()
                {
                    CheckInDate = bookingDto.CheckInDate,
                    CheckOutDate = bookingDto.CheckOutDate,
                    RoomId = roomId,
                    GuestId = guestId
                };
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task DeleteBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(string userId)
        {
            try
            {
                int guestId = _context.Users
                    .Where(e => e.Email == userId)
                    .Select(e => e.Id)
                    .FirstOrDefault();

                
                var bookings = await _context.Bookings
                                .Where(e => e.GuestId == guestId)
                                .ToListAsync();
                return bookings;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task UpdateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
