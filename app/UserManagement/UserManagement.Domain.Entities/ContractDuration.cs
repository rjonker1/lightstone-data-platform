using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractDuration : NamedEntity
    {
        public virtual string Value { get; set; }

        protected ContractDuration() { }

        public ContractDuration(Guid id, string val) : base(id, val)
        {
            Value = val;
        }
    }
}
