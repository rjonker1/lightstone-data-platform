using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserType : Entity
    {

        public virtual string Value { get; set; }
        public virtual ICollection<User> User { get; set; }

        public UserType()
        {
            User = new HashSet<User>();
        }

    }
}
