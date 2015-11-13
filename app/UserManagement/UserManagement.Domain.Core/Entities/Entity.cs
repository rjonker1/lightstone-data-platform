using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace UserManagement.Domain.Core.Entities
{
    [DataContract]
    public abstract class Entity : IEntity
    {
        [Required, DataMember]
        public virtual Guid Id { get; set; }

        protected internal Entity() { }

        protected Entity(Guid id)
        {
            Id = id == new Guid() ? Guid.NewGuid() : id;
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }

        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
