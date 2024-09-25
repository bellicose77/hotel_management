using hotel_management_API.Models;

namespace hotel_management_API.Service.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomByIdAsync(int roomId);
        Task<Room> CreateRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(int roomId);
    }
}
