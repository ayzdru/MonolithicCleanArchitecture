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
    public class DeleteTodoListCommand : IRequest<int>
    {
        public DeleteTodoListCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoListCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public DeleteTodoItemCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
            {
                var affected = await _applicationDbContext.TodoLists.GetById(request.Id).ExecuteDeleteAsync(cancellationToken);

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
