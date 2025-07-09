using CleanArchitecture.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Common;

namespace CleanArchitecture.Infrastructure.Common
{
    public abstract class BaseAuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.RowVersion).IsRowVersion();
            builder.HasQueryFilter(x => x.IsDeleted == false && x.IsActive == true);
        }
    }
}
