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
    public class DeleteTodoListItemCommand : IRequest<int>
    {
        public DeleteTodoListItemCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoListItemCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public DeleteTodoItemCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(DeleteTodoListItemCommand request, CancellationToken cancellationToken)
            {
                var affected = await _applicationDbContext.TodoListItems.GetById(request.Id).ExecuteDeleteAsync(cancellationToken);

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
