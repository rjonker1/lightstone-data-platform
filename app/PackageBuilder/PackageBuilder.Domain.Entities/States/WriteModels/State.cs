using System;
using PackageBuilder.Core.Entities;
using PackageBuilder.Core.NHibernate.Attributes;

namespace PackageBuilder.Domain.Entities.States.WriteModels
{
    public class State : Entity
    {
        protected State() { }

        [DomainSignature]
        public virtual string Name { get; set; }

        public State(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}