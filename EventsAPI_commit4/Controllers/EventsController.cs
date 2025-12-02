using EventsAPI.Models;
using EventsAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll(string? status = null)
        {
            var events = DataStore.Events.AsEnumerable();
            
            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<EventStatus>(status, ignoreCase: true, out var statusEnum))
                {
                    events = events.Where(e => e.Status == statusEnum);
                }
            }
            
            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetById(int id)
        {
            var evt = DataStore.Events.FirstOrDefault(e => e.Id == id);
            if (evt == null) return NotFound();
            return Ok(evt);
        }

        [HttpPost]
        public ActionResult<Event> Create([FromBody] Event evt)
        {
            evt.Id = DataStore.Events.Max(e => e.Id) + 1;
            DataStore.Events.Add(evt);
            return CreatedAtAction(nameof(GetById), new { id = evt.Id }, evt);
        }

        [HttpPut("{id}")]
        public ActionResult<Event> Update(int id, [FromBody] Event evt)
        {
            var existing = DataStore.Events.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();

            existing.Title = evt.Title;
            existing.CustomerId = evt.CustomerId;
            existing.RoomId = evt.RoomId;
            existing.Status = evt.Status;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var evt = DataStore.Events.FirstOrDefault(e => e.Id == id);
            if (evt == null) return NotFound();

            DataStore.Events.Remove(evt);
            return NoContent();
        }
    }
}
