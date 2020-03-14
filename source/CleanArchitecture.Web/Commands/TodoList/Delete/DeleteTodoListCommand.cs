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
    public class DeleteTodoListCommand : IRequest<int>
    {
        public DeleteTodoListCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoListCommand, int>
        {
            private readonly ApplicationDbContext _applicationDbContext;

            public DeleteTodoItemCommandHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
            {
                var affected = await _applicationDbContext.TodoLists.GetById(request.Id).BatchDeleteAsync();

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
