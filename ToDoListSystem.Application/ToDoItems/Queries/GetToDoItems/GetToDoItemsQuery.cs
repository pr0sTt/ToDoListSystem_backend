using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoListSystem.Application.Common.Interfaces;

namespace ToDoListSystem.Application.ToDoItems.Queries.GetToDoItems
{
    public record GetToDoItemsQuery : IRequest<List<ToDoItemDto>>;

    public class GetToDoItemsQueryHandler : IRequestHandler<GetToDoItemsQuery, List<ToDoItemDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetToDoItemsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItemDto>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.ToDoItems
                .Select(item => new ToDoItemDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Status = item.Status.ToString().ToLowerInvariant(),
                    Deadline = item.Deadline.HasValue
                        ? DateTime.SpecifyKind(item.Deadline.Value, DateTimeKind.Utc)
                        : null
                })
                .ToListAsync(cancellationToken);
        }
    }
}
