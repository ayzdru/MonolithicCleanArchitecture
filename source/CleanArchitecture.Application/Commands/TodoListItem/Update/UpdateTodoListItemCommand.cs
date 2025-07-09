using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces;
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
            private readonly ICurrentUserService _currentUserService;
            public UpdateTodoListItemCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
            {
                _applicationDbContext = applicationDbContext;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(UpdateTodoListItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await _applicationDbContext.TodoListItems.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }

                entity.SetIsDone(request.IsDone);

                _applicationDbContext.TodoListItems.Update(entity);
                var affected = await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return affected;
            }
        }
    }
}
