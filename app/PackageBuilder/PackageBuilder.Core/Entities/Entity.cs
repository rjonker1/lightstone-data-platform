using System;

namespace PackageBuilder.Core.Entities
{
    [Serializable]
    public abstract class Entity
    {
        protected Entity() { }

        protected Entity(Guid id)
        {
            Id =  id == new Guid() ? Guid.NewGuid() : id;
        }

        public virtual Guid Id { get; protected set; }
    }
}