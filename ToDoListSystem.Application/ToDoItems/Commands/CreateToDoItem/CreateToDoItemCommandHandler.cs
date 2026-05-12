using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ToDoListSystem.Domain.Entities;
using ToDoListSystem.Application.Common.Interfaces;

namespace ToDoListSystem.Application.ToDoItems.Commands.CreateToDoItem
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateToDoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new ToDoItem
            {
                Title = request.Title,
                Description = request.Description,
                Deadline = request.Deadline
            };

            _context.ToDoItems.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
