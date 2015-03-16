using System;
using System.ComponentModel.DataAnnotations;
using Billing.Domain.Core.NHibernate;

namespace Billing.Domain.Core.Entities
{
    public class NamedEntity : Entity, INamedEntity
    {
        [Required, DomainSignature]
        public virtual string Name { get; protected internal set; }

        protected NamedEntity() { }

        protected NamedEntity(string name, Guid id = new Guid())
            : base(id)
        {
            Name = name;
        }
    }
}