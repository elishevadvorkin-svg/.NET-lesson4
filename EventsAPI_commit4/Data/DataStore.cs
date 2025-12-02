using EventsAPI.Models;

namespace EventsAPI.Data
{
    public static class DataStore
    {
        public static List<Event> Events { get; set; } = new List<Event>
        {
            new Event { Id = 1, Title = "Company Meeting", CustomerId = 1, RoomId = 1, Status = EventStatus.Planned },
            new Event { Id = 2, Title = "Team Lunch", CustomerId = 2, RoomId = 2, Status = EventStatus.Ongoing },
            new Event { Id = 3, Title = "Conference", CustomerId = 1, RoomId = 3, Status = EventStatus.Completed }
        };

        public static List<Customer> Customers { get; set; } = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "0501234567", IsActive = true },
            new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Phone = "0507654321", IsActive = true },
            new Customer { Id = 3, Name = "Bob Johnson", Email = "bob@example.com", Phone = "0509876543", IsActive = false }
        };

        public static List<Room> Rooms { get; set; } = new List<Room>
        {
            new Room { Id = 1, Name = "Conference Room A", Capacity = 50, Location = "Floor 1" },
            new Room { Id = 2, Name = "Meeting Room B", Capacity = 20, Location = "Floor 2" },
            new Room { Id = 3, Name = "Auditorium C", Capacity = 200, Location = "Floor 3" }
        };
    }
}
