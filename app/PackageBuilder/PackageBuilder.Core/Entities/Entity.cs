using System;
using System.Runtime.Serialization;

namespace PackageBuilder.Core.Entities
{
    [DataContract]
    public abstract class Entity
    {
        [DataMember]
        public virtual Guid Id { get; protected set; }

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id =  id == new Guid() ? Guid.NewGuid() : id;
        }
    }
}