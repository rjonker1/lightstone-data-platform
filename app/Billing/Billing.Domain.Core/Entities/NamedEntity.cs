using System;
using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Core.Entities
{
    public class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public virtual string Name { get; set; }

        protected NamedEntity() { }

        protected NamedEntity(string name, Guid id = new Guid())
            : base(id)
        {
            Name = name;
        }
    }
}