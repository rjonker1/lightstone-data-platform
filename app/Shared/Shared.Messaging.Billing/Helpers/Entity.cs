using System;

namespace Shared.Messaging.Billing.Helpers
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public Entity() { }

        public Entity(Guid id)
        {
            Id = id == new Guid() ? Guid.NewGuid() : id;
        }

        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
    }
}