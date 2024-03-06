using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using System.Threading;
using CleanArchitecture.Application.Notifications;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Commands
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
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly IMediator _mediator;
            public CreateTodoListItemCommandHandler(IApplicationDbContext applicationDbContext, IMediator mediator)
            {
                _applicationDbContext = applicationDbContext;
                _mediator = mediator;
            }
            public async Task<Guid?> Handle(CreateTodoListItemCommand request, CancellationToken cancellationToken)
            {
                _applicationDbContext.TodoListItems.Add(request.TodoListItem);
                request.TodoListItem.AddNotification(new TodoListItemCreatedNotification { Title = request.TodoListItem.Title });
                var affected = await _applicationDbContext.SaveChangesAsync(cancellationToken);
                if (affected != 0)
                {                   
                    return request.TodoListItem.Id;
                }
                return null;
            }
        }
    }
}
