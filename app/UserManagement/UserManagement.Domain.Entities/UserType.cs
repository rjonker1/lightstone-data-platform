using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserType : Entity, INamedEntity
    {
        //Required for NamedEntity Comparison
        public virtual string Name { get; set; }

        public virtual string Value { get; set; }
        public virtual ICollection<User> User { get; set; }

        protected UserType() { }

        public UserType(Guid _id, string val)
        {
            Id = _id;
            Name = val;
            Value = val;
            User = new HashSet<User>();
        }

    }
}
