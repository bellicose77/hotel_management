using hotel_management_API.Models.DTO;

namespace hotel_management_API.Service.Interface
{
    public interface IDashboardService
    {
        Task<List<BookingDetailsDto>> GetAllBooingInfo();
    }
}
