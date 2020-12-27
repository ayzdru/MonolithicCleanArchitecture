using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Queries
{
    public class GetTodoListsQuery :  IRequest<List<TodoListViewModel>>
    {
        public class GetTodoListsQueryQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoListViewModel>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetTodoListsQueryQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<List<TodoListViewModel>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
            {
                return _applicationDbContext.TodoLists.Select(q => new TodoListViewModel(q.Id, q.Title, q.TodoListItems.Count())).ToListAsync(cancellationToken);
            }
        }
    }
}
