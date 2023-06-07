﻿using CleanArchitecture.Application.Extensions;
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
                
                var affected = await _applicationDbContext.TodoLists.GetById(request.Id).ExecuteUpdateAsync(setters => setters.SetProperty(b => b.Title, request.Title).SetProperty(b=> b.LastModifiedByUserId, _currentUserService.UserId).SetProperty(b=> b.LastModified , DateTime.Now));

                if (affected == 0)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }              

                return affected;
            }
        }
    }
}
