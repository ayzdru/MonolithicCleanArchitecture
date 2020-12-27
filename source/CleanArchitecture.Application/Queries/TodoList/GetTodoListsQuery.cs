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
    public class GetTodoListsQuery :  IRequest<IQueryable<TodoList>>
    {
        public class GetTodoListsQueryQueryHandler : IRequestHandler<GetTodoListsQuery, IQueryable<TodoList>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetTodoListsQueryQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<IQueryable<TodoList>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_applicationDbContext.TodoLists.AsQueryable());
            }
        }
    }
}
