using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Commands
{    
    public class UpdateTodoListCommand : IRequest<int>
    {        

        public Guid Id { get; set; }
        public string Title { get; set; }
        public UpdateTodoListCommand(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly ICurrentUserService _currentUserService;

            public UpdateTodoListCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
            {
                _applicationDbContext = applicationDbContext;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
            {
                var todoList = await _applicationDbContext.TodoLists
                    .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (todoList == null)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }

                todoList.SetTitle(request.Title);
                _applicationDbContext.TodoLists.Update(todoList);
                  var affected = await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return affected;
            }
        }
    }
}
