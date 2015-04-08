using System;

namespace Shared.Messaging.Billing.Helpers
{
    public class Entity : IEntity
    {
        public virtual Guid Id { get; set; }

        public Entity() { }

        public Entity(Guid id)
        {
            Id = id == new Guid() ? Guid.NewGuid() : id;
        }

        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}