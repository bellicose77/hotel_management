using hotel_management_API.Models;
using hotel_management_API.Models.DTO;
using hotel_management_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel_management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Createbooking(BookingDto booking)
        {
            var result = await _bookingService.CreateBookingAsync(booking);
            return Ok(result);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Booking>> GetBooking(string email)
        {
            var result = await _bookingService.GetAllBookingsAsync(email);
            return Ok(result);
        }
    }
}
