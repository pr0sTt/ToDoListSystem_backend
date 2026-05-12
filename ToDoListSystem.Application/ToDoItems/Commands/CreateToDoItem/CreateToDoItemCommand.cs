using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ToDoListSystem.Application.ToDoItems.Commands.CreateToDoItem
{
    public record CreateToDoItemCommand(string Title, string? Description, DateTime? Deadline) : IRequest<Guid>;
}
