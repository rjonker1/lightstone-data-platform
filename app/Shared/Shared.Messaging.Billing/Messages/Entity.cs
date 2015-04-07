using System;
using DataPlatform.Shared.Messaging;

namespace Shared.Messaging.Billing.Messages
{
    public class Entity : IEntity, IPublishableMessage
    {
        public Guid Id { get; set; }

        protected internal Entity() { }

        protected Entity(Guid id)
        {
            Id = id == new Guid() ? Guid.NewGuid() : id;
        }

        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
    }
}