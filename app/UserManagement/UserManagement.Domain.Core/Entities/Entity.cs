using System;
using System.Runtime.Serialization;

namespace UserManagement.Domain.Core.Entities
{
    [DataContract]
    public abstract class Entity : IEntity
    {
        [DataMember]
        public virtual Guid Id { get; protected internal set; }

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }


        public virtual DateTime? Modified { get; protected internal set; }
        public virtual string ModifiedBy { get; protected internal set; }
        public virtual DateTime? Created { get; protected internal set; }
        public virtual string CreatedBy { get; protected internal set; }
    }
}
