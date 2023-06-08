using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Extensions;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Infrastructure.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
    {
        private readonly IMediator _mediator;
        private readonly EntitySaveChangesInterceptor _entitySaveChangesInterceptor;
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoListItem> TodoListItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator, EntitySaveChangesInterceptor entitySaveChangesInterceptor)
             : base(options)
        {
            _mediator = mediator;
            _entitySaveChangesInterceptor = entitySaveChangesInterceptor;
        }      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_entitySaveChangesInterceptor);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchNotifications(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
