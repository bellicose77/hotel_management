using hotel_management_API.Models;
using hotel_management_API.Models.DTO;

namespace hotel_management_API.Service.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<RoomDetailsDto?> GetRoomByIdAsync(int roomId);
        Task<Room> CreateRoomAsync(RoomDto room);
        Task<bool> UpdateRoomAsync(RoomDto room);
        Task DeleteRoomAsync(int roomId);
        Task<IEnumerable<String>> GetAllRoomTypes();
    }
}
