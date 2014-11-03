using System;
using PackageBuilder.Core.Entities;
using PackageBuilder.Core.NHibernate.Attributes;
using PackageBuilder.Domain.Entities.Enums;

namespace PackageBuilder.Domain.Entities.States.WriteModels
{
    public class State : Entity
    {
        [DomainSignature]
        public virtual StateName Name { get; set; }
        public virtual string Alias { get; set; }

        protected State() { }

        public State(Guid id, StateName name, string alias)
            : base(id)
        {
            Name = name;
            Alias = alias;
        }
    }
}