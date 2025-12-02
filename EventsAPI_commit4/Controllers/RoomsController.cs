using EventsAPI.Models;
using EventsAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetAll()
        {
            return Ok(DataStore.Rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetById(int id)
        {
            var room = DataStore.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public ActionResult<Room> Create([FromBody] Room room)
        {
            room.Id = DataStore.Rooms.Max(r => r.Id) + 1;
            DataStore.Rooms.Add(room);
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public ActionResult<Room> Update(int id, [FromBody] Room room)
        {
            var existing = DataStore.Rooms.FirstOrDefault(r => r.Id == id);
            if (existing == null) return NotFound();

            existing.Name = room.Name;
            existing.Capacity = room.Capacity;
            existing.Location = room.Location;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var room = DataStore.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null) return NotFound();

            DataStore.Rooms.Remove(room);
            return NoContent();
        }
    }
}
