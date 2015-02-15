using System;
using System.Runtime.Serialization;

namespace UserManagement.Domain.Core.Entities
{
    [DataContract]
    public abstract class Entity : IEntity
    {
        [DataMember]
        public virtual Guid Id { get; set; }

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }


        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}
