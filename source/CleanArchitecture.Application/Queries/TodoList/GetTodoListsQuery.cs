using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Models;
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
    public class GetTodoListsQuery :  IRequest<List<TodoListModel>>
    {
        public class GetTodoListsQueryQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoListModel>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetTodoListsQueryQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<List<TodoListModel>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
            {
                return _applicationDbContext.TodoLists.Select(q => new TodoListModel(q.Id, q.Title, q.TodoListItems.Count())).ToListAsync(cancellationToken);
            }
        }
    }
}
