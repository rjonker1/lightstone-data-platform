using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserType : NamedEntity
    {
        public virtual string Value { get; set; }

        protected UserType() { }

        public UserType(Guid id, string name) : base(id, name)
        {
            Value = name;
        }
    }
}
