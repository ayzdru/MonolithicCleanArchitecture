using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Queries
{
    public class GetTodoListsQuery :  IRequest<List<TodoList>>
    {
        public class GetWeatherForecastsQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoList>>
        {
            private readonly ApplicationDbContext _applicationDbContext;

            public GetWeatherForecastsQueryHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<TodoList>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.TodoLists.ToListAsync();
            }
        }
    }
}
