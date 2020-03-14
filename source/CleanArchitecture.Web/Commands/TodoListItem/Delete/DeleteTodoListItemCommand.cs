using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Extensions;
using EFCore.BulkExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Commands
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
            private readonly ApplicationDbContext _applicationDbContext;

            public DeleteTodoItemCommandHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(DeleteTodoListItemCommand request, CancellationToken cancellationToken)
            {
                var affected = await _applicationDbContext.TodoListItems.GetById(request.Id).BatchDeleteAsync();

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
