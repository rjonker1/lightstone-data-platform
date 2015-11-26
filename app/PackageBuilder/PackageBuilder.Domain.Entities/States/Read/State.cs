using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Entities;
using PackageBuilder.Core.NHibernate.Attributes;
using PackageBuilder.Domain.Entities.Contracts.States.Read;
using PackageBuilder.Domain.Entities.Enums.States;

namespace PackageBuilder.Domain.Entities.States.Read
{
    public class State : Entity, IState
    {
        [DomainSignature, DataMember]
        public virtual StateName Name { get; set; }
        [DataMember]
        public virtual string Alias { get; set; }

        protected State() { }

        public State(Guid id, StateName name, string alias)
            : base(id)
        {
            Name = name;
            Alias = alias;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}