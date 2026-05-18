using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListSystem.Application.Common.Interfaces;
using ToDoListSystem.Domain.Entities;

namespace ToDoListSystem.Application.ToDoItems.Commands.UpdateToDoItem
{
    public record UpdateToDoItemCommand(
        Guid Id,
        string Title,
        string? Description,
        string Status,
        DateTime? Deadline) : IRequest<bool>;

    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateToDoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ToDoItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                return false;
            }

            entity.Title = request.Title;
            entity.Description = request.Description;

            if (request.Deadline.HasValue)
            {
                entity.Deadline = DateTime.SpecifyKind(request.Deadline.Value, DateTimeKind.Utc);
            }
            else
            {
                entity.Deadline = null;
            }

            var cleanStatus = request.Status.ToLowerInvariant().Replace("-", "");
            entity.Status = cleanStatus switch
            {
                "todo" => ToDoStatus.Todo,
                "inprogress" => ToDoStatus.InProgress,
                "done" => ToDoStatus.Done,
                _ => entity.Status
            };

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
