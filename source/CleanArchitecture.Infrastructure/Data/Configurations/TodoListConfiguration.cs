using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.Configurations
{
    public class TodoListConfiguration : BaseConfiguration<TodoList>
    {
        public override void Configure(EntityTypeBuilder<TodoList> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Title).HasMaxLength(Constants.TodoList.TitleMaximumLength).IsRequired(Constants.TodoList.TitleRequired);
            builder.OwnsOne(b => b.Colour, ba=> {
                ba.Property(p => p.Code).HasMaxLength(Constants.Colour.CodeMaximumLength).IsRequired(Constants.Colour.CodeIsRequired);
                
            });
            builder.OwnsOne(b => b.Colour, ba =>
            {
                ba.Property(p => p.Code)
                    .HasColumnName("ColourCode")
                    .HasMaxLength(Constants.Colour.CodeMaximumLength)
                    .IsRequired(Constants.Colour.CodeIsRequired);
            });
            builder.Navigation(n=> n.TodoListItems).UsePropertyAccessMode(PropertyAccessMode.Field);
        }        
    }
}
