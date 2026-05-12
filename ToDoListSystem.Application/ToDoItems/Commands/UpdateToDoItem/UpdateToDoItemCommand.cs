using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListSystem.Application.Common.Interfaces;

namespace ToDoListSystem.Application.ToDoItems.Commands.UpdateToDoItem
{
    public record UpdateToDoItemCommand(
        Guid Id,
        string Title,
        string? Description,
        bool IsCompleted,
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
            entity.Deadline = request.Deadline;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
