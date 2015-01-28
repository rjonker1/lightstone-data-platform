using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractType : Entity, INamedEntity
    {

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        protected ContractType() { }

        public ContractType(Guid id, string val) : base(id)
        {
            Name = val;
            Value = val;
        }
    }
}
