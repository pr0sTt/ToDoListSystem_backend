using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListSystem.Application.ToDoItems.Queries
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
    }
}
