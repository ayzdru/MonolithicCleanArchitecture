using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Web.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Queries
{
    public class GetTodoListsQuery :  IRequest<List<TodoListViewModel>>
    {
        public class GetTodoListsQueryQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoListViewModel>>
        {
            private readonly ApplicationDbContext _applicationDbContext;

            public GetTodoListsQueryQueryHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<TodoListViewModel>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.TodoLists.Select(q=> new TodoListViewModel(q.Id, q.Title, q.TodoListItems.Count())).ToListAsync();
            }
        }
    }
}
