using System;

namespace UserManagement.Domain.Core.Entities
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public virtual string Name { get; protected internal set; }

        protected NamedEntity() { }

        protected NamedEntity(string name, Guid id = new Guid()) : base(id)
        {
            Name = name;
        }

    }
}