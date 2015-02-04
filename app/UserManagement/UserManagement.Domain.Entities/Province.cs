using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Province : NamedEntity
    {
        public virtual string Value { get; set; }

        protected Province() { }

        public Province(Guid id, string val) : base(id, val)
        {
            Value = val;
        }
    }
}
