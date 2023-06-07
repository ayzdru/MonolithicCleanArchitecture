using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoListItem> TodoListItems { get; set; }
        DbSet<TodoList> TodoLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}