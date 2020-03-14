using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Web.ApiModels;
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
    public class GetTodoListItemsQuery :  IRequest<List<TodoListItemApiModel>>
    {       
        public Guid TodoListId { get; set; }
        public GetTodoListItemsQuery(Guid todoListId)
        {
            TodoListId = todoListId;
        }
        public class GetTodoListItemsQueryHandler : IRequestHandler<GetTodoListItemsQuery, List<TodoListItemApiModel>>
        {
            private readonly ApplicationDbContext _applicationDbContext;

            public GetTodoListItemsQueryHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<TodoListItemApiModel>> Handle(GetTodoListItemsQuery request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.TodoListItems.GetByTodoListId(request.TodoListId).Select(q=> new TodoListItemApiModel(q.Id, q.Title, q.Description,q.IsDone)).ToListAsync();
            }
        }
    }
}
