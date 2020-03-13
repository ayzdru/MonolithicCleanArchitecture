using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Configurations
{
    public class TodoListItemConfiguration : BaseConfiguration<TodoListItem>
    {
        public override void Configure(EntityTypeBuilder<TodoListItem> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Title).HasMaxLength(Constants.TodoListItem.Title.MaximumLength).IsRequired(Constants.TodoListItem.Title.Required);
            builder.Property(b => b.Description).HasMaxLength(Constants.TodoListItem.Description.MaximumLength).IsRequired(Constants.TodoListItem.Description.Required);
            builder.Property(b => b.IsDone).IsRequired(Constants.TodoListItem.IsDoneRequired);
            builder.HasOne(b => b.TodoList).WithMany(b => b.TodoListItems).HasForeignKey(b => b.TodoListId);           
        }
    }
}
