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
    public class CreateTodoListCommand : IRequest<Guid?>
    {
        public TodoList TodoList { get; set; }
        public CreateTodoListCommand(TodoList todoList)
        {

            TodoList = todoList;
        }
        public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid?>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMediator _mediator;
            public CreateTodoListCommandHandler(ApplicationDbContext applicationDbContext, IMediator mediator)
            {
                _applicationDbContext = applicationDbContext;
                _mediator = mediator;
            }
            public async Task<Guid?> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
            {
                _applicationDbContext.TodoLists.Add(request.TodoList);                    
                var affected = await _applicationDbContext.SaveChangesAsync();
                if (affected != 0)
                {
                    await _mediator.Publish(new TodoListCreatedNotification { Title = request.TodoList.Title }, cancellationToken);
                    return request.TodoList.Id;
                }
                return null;
            }
        }
    }
}
