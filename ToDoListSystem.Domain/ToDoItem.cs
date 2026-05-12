using System.Runtime.InteropServices;

namespace ToDoListSystem.Domain.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ToDoItem()
        {
            Id = Guid.NewGuid();
            Status = ToDoStatus.Todo;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
