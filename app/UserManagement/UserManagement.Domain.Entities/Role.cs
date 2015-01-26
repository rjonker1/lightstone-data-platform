using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Role : Entity, INamedEntity
    {

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        protected Role() { }

        public Role(Guid id, string val) : base(id)
        {
            Name = val;
            Value = val;
        }

    }
}
