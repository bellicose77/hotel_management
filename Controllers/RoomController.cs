using hotel_management_API.Models;
using hotel_management_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await _roomService.GetAllRoomsAsync());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            await _roomService.CreateRoomAsync(room);
            return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            try
            {
                await _roomService.UpdateRoomAsync(room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _roomService.GetRoomByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }
}
