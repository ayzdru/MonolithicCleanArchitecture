using CleanArchitecture.Core;
using CleanArchitecture.Core.Common;
using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Common
{
    public abstract class BaseAuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.RowVersion).IsRowVersion(); 

            builder.HasOne<User>(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>(e => e.UpdatedByUser)
                .WithMany()
                .HasForeignKey(e => e.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => x.IsDeleted == false && x.IsActive == true);
        }
    }
}
