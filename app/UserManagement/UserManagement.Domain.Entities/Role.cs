using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.Roles;

namespace UserManagement.Domain.Entities
{
    public class Role : Entity, INamedEntity
    {

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual IList<User> Users { get; set; }

        protected Role() { }

        public Role(Guid _id, string val)
        {
            Id = _id;
            Name = val;
            Value = val;
            //Users = new HashSet<UserRole>();
        }

    }
}
