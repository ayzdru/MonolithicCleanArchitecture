using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public ApplicationUser CreatedByUser { get; protected set; }
        public Guid? CreatedByUserId { get; protected set; }
        public DateTime Created { get; protected set; }
        public ApplicationUser LastModifiedByUser { get; protected set; }
        public Guid? LastModifiedByUserId { get; protected set; }
        public DateTime? LastModified { get; protected set; }
        public byte[] RowVersion { get; protected set; }
    }
}
