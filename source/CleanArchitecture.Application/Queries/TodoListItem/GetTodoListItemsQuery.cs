using CleanArchitecture.Application;
using CleanArchitecture.Application.Extensions;
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
    public class GetTodoListItemsQuery :  IRequest<IQueryable<TodoListItem>>
    {       
        public Guid TodoListId { get; set; }
        public GetTodoListItemsQuery(Guid todoListId)
        {
            TodoListId = todoListId;
        }
        public class GetTodoListItemsQueryHandler : IRequestHandler<GetTodoListItemsQuery, IQueryable<TodoListItem>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetTodoListItemsQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<IQueryable<TodoListItem>> Handle(GetTodoListItemsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_applicationDbContext.TodoListItems.GetByTodoListId(request.TodoListId).AsQueryable());
            }
        }
    }
}
