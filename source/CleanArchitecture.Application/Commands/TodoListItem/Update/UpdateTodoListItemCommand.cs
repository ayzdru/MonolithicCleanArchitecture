using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands
{    
    public class UpdateTodoListItemCommand : IRequest<int>
    {        

        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public UpdateTodoListItemCommand(Guid id, bool isDone)
        {
            Id = id;
            IsDone = isDone;
        }

        public class UpdateTodoListItemCommandHandler : IRequestHandler<UpdateTodoListItemCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public UpdateTodoListItemCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(UpdateTodoListItemCommand request, CancellationToken cancellationToken)
            {                
                var affected = await _applicationDbContext.TodoListItems.GetById(request.Id).ExecuteUpdateAsync(setters => setters.SetProperty(b => b.IsDone, request.IsDone));

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
