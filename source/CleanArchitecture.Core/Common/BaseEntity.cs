using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Core.Common
{
    public abstract class BaseEntity : BaseAuditableEntity
    {
        public Guid Id { get; protected set; }
    }
}
