using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserAlias : Entity
    {
        public virtual string UuId { get; protected internal set; }
        public virtual string FirstName { get; protected internal set; }
        public virtual string LastName { get; protected internal set; }
        public virtual string UserName { get; protected internal set; }
        public virtual ISet<User> Users { get; protected internal set; } 
    }
}