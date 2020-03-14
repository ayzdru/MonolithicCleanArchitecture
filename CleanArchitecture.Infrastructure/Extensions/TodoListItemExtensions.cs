using CleanArchitecture.Core;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Infrastructure.Extensions
{
    public static class TodoListItemExtensions
    {
        public static IQueryable<TodoListItem> GetByTodoListId(this DbSet<TodoListItem> dbSet, Guid todoListId)
        {
            return dbSet.Where(q => q.TodoListId == todoListId);
        }
    }
}
