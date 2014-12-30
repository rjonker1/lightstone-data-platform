using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Role : Entity
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public string Value { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
