using hotel_management_API.Models;
using hotel_management_API.Models.DTO;
using hotel_management_API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_API.Service.Service
{
    public class RoomService:IRoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(int roomId)
        {
            return await _context.Rooms.FindAsync(roomId);
        }

        public async Task<Room> CreateRoomAsync(RoomDto dto)
        {
            try
            {
                Room room = new Room()
                {
                    Id = dto.Id,
                    PricePerNight = dto.PricePerNight,
                    RoomNumber = dto.RoomNumber,
                    Capacity = dto.Capacity,
                    RoomType = dto.RoomType,
                    Status = dto.Status,
                };
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
