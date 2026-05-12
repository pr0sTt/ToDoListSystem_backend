using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ToDoListSystem.Application.Common.Interfaces;

namespace ToDoListSystem.Application.ToDoItems.Commands.DeleteToDoItem
{
    public record DeleteToDoItemCommand(Guid Id) : IRequest<bool>;

    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteToDoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ToDoItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                return false;
            }

            _context.ToDoItems.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
