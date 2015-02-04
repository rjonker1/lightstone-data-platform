using System;

namespace UserManagement.Domain.Core.Entities
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public virtual string Name { get; protected internal set; }

        protected NamedEntity() { }

        protected NamedEntity(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}