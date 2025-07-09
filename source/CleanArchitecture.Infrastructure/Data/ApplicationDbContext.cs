using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Extensions;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Infrastructure.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoListItem> TodoListItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            ConfigureIdentity(builder);
        }
        private void ConfigureIdentity(ModelBuilder builder)
        {
            builder.Entity<Role>().ToTable(Constants.Identity.Roles);
            builder.Entity<RoleClaim>().ToTable(Constants.Identity.RoleClaims);
            builder.Entity<UserRole>().ToTable(Constants.Identity.UserRoles);
            builder.Entity<User>().ToTable(Constants.Identity.Users);
            builder.Entity<UserLogin>().ToTable(Constants.Identity.UserLogins);
            builder.Entity<UserClaim>().ToTable(Constants.Identity.UserClaims);
            builder.Entity<UserToken>().ToTable(Constants.Identity.UserTokens);            
        }

    }
}
