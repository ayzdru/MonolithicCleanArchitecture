using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using System.Threading;
using CleanArchitecture.Web.Notifications;

namespace CleanArchitecture.Web.Commands
{
    public class CreateTodoListItemCommand : IRequest<Guid?>
    {
        public TodoListItem TodoListItem { get; set; }
        public CreateTodoListItemCommand(TodoListItem todoListItem)
        {

            TodoListItem = todoListItem;
        }
        public class CreateTodoListItemCommandHandler : IRequestHandler<CreateTodoListItemCommand, Guid?>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMediator _mediator;
            public CreateTodoListItemCommandHandler(ApplicationDbContext applicationDbContext, IMediator mediator)
            {
                _applicationDbContext = applicationDbContext;
                _mediator = mediator;
            }
            public async Task<Guid?> Handle(CreateTodoListItemCommand request, CancellationToken cancellationToken)
            {
                _applicationDbContext.TodoListItems.Add(request.TodoListItem);                    
                var affected = await _applicationDbContext.SaveChangesAsync();
                if (affected != 0)
                {
                    return request.TodoListItem.Id;
                }
                return null;
            }
        }
    }
}
