using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {

        public virtual Guid Id { get; protected internal set; }
        public virtual DateTime FirstCreateDate { get; protected internal set; }
        public virtual string LastUpdateBy { get; protected internal set; }
        public virtual DateTime LastUpdateDate { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual string UserName { get; protected internal set; }
        public virtual Guid UserTypeId { get; protected internal set; }

        public User()
        {
        }

    }
}
