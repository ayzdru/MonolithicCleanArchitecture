using CleanArchitecture.Application.DataTransferObjects;
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
    public class GetTodoListsQuery :  IRequest<List<TodoListDTO>>
    {
        public class GetTodoListsQueryQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoListDTO>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetTodoListsQueryQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<List<TodoListDTO>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
            {
                return _applicationDbContext.TodoLists.Select(q => new TodoListDTO(q.Id, q.Title, q.TodoListItems.Count())).ToListAsync(cancellationToken);
            }
        }
    }
}
