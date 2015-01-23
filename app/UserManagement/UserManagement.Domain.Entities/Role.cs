using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Role : Entity, INamedEntity
    {

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        protected Role() { }

        public Role(Guid _id, string val)
        {
            Id = _id;
            Name = val;
            Value = val;
        }

    }
}
