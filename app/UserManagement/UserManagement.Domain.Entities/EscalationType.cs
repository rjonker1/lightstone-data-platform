using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class EscalationType : NamedEntity
    {
        public virtual string Value { get; set; }

        protected EscalationType() { }

        public EscalationType(Guid id, string val) : base(id, val)
        {
            Value = val;
        }
    }
}
