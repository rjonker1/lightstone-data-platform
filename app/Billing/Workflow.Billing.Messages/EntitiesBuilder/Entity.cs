using System;
using Workflow.Billing.Messages.Entities;

namespace Workflow.Billing.Messages.EntitiesBuilder
{
    public class Entity : IEntity
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