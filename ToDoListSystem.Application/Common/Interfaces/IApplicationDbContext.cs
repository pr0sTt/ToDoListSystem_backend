using System;
using System.Collections.Generic;
using System.Text;
using ToDoListSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoListSystem.Domain.Entities;

namespace ToDoListSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ToDoItem> ToDoItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
