namespace EventsAPI.Models
{
    public enum EventStatus
    {
        Planned,
        Ongoing,
        Completed,
        Cancelled
    }

    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public EventStatus Status { get; set; }
    }
}
