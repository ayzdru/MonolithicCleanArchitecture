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

            public UpdateTodoListCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
            {
                
                var affected = await _applicationDbContext.TodoLists.GetById(request.Id).ExecuteUpdateAsync(setters => setters.SetProperty(b => b.Title, request.Title));

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
