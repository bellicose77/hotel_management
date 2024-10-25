using hotel_management_API.Models;
using hotel_management_API.Models.DTO;
using hotel_management_API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_API.Service.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;
      
        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<List<BookingDetailsDto>> GetAllBooingInfo()
        {
            List<BookingDetailsDto> result = new List<BookingDetailsDto>();
            try
            {
                result = await(from a in  _context.Bookings
                                      join b in _context.Users on a.GuestId equals b.Id
                                      join c in _context.Rooms on a.RoomId equals c.Id

                                      select new BookingDetailsDto()
                                      {
                                          GuestName=b.FirstName+" "+b.LastName,
                                          GuestEmail=b.Email,
                                          GuestPhone=b.PhoneNumber,
                                          BookingDate=a.CreatedAt,
                                          CheckinDate=a.CheckInDate,
                                          CheckoutDate=a.CheckOutDate,
                                          RoomNumber=c.Id,
                                          RoomType=c.RoomType,

                                      }).ToListAsync();
                return result;             
            }
            catch (Exception ex)
            {
                return result;
            }

           

        }
    }
}
