using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public void Create(Guid? createdByUserId)
        {
            CreatedByUserId = createdByUserId;
            Created = DateTime.Now;
        }
        public void Update(Guid? lastModifiedByUserId)
        {
            if (lastModifiedByUserId.HasValue)
            {
                LastModifiedByUserId = lastModifiedByUserId;
                LastModified = DateTime.Now;
            }
        }
        private readonly List<BaseEvent> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
