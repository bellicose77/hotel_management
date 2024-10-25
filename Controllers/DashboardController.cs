using hotel_management_API.Models.DTO;
using hotel_management_API.Service.Interface;
using hotel_management_API.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel_management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet("booking-info")]
        public async Task<IActionResult> GetAllBookingInfo()
        {
            try
            {
                List<BookingDetailsDto> bookingInfo = await _dashboardService.GetAllBooingInfo();

                if (bookingInfo == null || bookingInfo.Count == 0)
                {
                    return NotFound("No booking information found.");
                }

                return Ok(bookingInfo);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
