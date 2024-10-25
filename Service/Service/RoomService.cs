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

        public async Task<IEnumerable<String>> GetAllRoomTypes()
        {
            return await _context.Rooms.Select(e => e.RoomType).ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetRoomByIdAsync(int roomId)
        {
            return await (from room in _context.Rooms join roomDetails in _context.RoomDetails
                                on room.Id equals roomDetails.RoomId
                                where room.Id == roomId
                                select new RoomDetailsDto
                                {
                                    PricePerNight = room.PricePerNight,
                                    RoomType = room.RoomType,
                                    Wifi = roomDetails.Wifi,
                                    Description = room.Description,
                                    Bed = roomDetails.Bed,
                                    Capacity = room.Capacity,
                                    AirConditioning = roomDetails.AirConditioning,
                                    Tv = roomDetails.Tv,
                                    RoomService = roomDetails.RoomService,
                                    Laundry = roomDetails.Laundry,
                                    CoffeeMaker = roomDetails.CoffeeMaker,
                                    Image = room.Image
                                }).FirstOrDefaultAsync();
        }

        public async Task<Room> CreateRoomAsync(RoomDto dto)
        {
            try
            {
                Room room = new Room()
                {
                    Id = dto.Id,
                    PricePerNight = dto.PricePerNight,
                    Capacity = dto.Capacity,
                    RoomType = dto.RoomType,
                    Description = dto.Description,
                    Image = dto.Image
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

        public async Task<bool> UpdateRoomAsync(RoomDto dto)
        {
            try
            {
                Room? room = await _context.Rooms.Where(r => r.Id == dto.Id).FirstOrDefaultAsync();
                if (room == null) { 
                    return false;
                }
                room.PricePerNight = dto.PricePerNight;
                //room.RoomNumber = dto.RoomNumber;
                room.Capacity = dto.Capacity;
                room.RoomType = dto.RoomType;
                //room.Status = dto.Status;   
                _context.Rooms.Update(room);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
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
