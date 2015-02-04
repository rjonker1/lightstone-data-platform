using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractType : NamedEntity
    {
        public virtual string Value { get; protected internal set; }

        protected ContractType() { }

        public ContractType(Guid id, string val) : base(id, val)
        {
            Value = val;
        }
    }
}
