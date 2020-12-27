using CleanArchitecture.Application;
using CleanArchitecture.Application.ApiModels;
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
    public class GetTodoListItemsQuery :  IRequest<List<TodoListItemApiModel>>
    {       
        public Guid TodoListId { get; set; }
        public GetTodoListItemsQuery(Guid todoListId)
        {
            TodoListId = todoListId;
        }
        public class GetTodoListItemsQueryHandler : IRequestHandler<GetTodoListItemsQuery, List<TodoListItemApiModel>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetTodoListItemsQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<List<TodoListItemApiModel>> Handle(GetTodoListItemsQuery request, CancellationToken cancellationToken)
            {
                return _applicationDbContext.TodoListItems.GetByTodoListId(request.TodoListId).Select(q => new TodoListItemApiModel(q.Id, q.Title, q.Description, q.IsDone)).ToListAsync(cancellationToken);
            }
        }
    }
}
