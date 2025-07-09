using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Interfaces;
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
    public class DeleteTodoListCommand : IRequest<int>
    {
        public DeleteTodoListCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public DeleteTodoListCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
            {
                var todoList = await _applicationDbContext.TodoLists
                    .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (todoList == null)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }

                _applicationDbContext.TodoLists.Remove(todoList);

                var affected = await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return affected;
            }
        }
    }
}
