using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity, IUser
    {

        private readonly IList<IUserRole> _listedUserRoles = new List<IUserRole>();

        public User()
        {
        }

        public virtual Guid Id { get; protected internal set; }
        public virtual DateTime FirstCreateDate { get; protected internal set; }
        public virtual string LastUpdateBy { get; protected internal set; }
        public virtual DateTime LastUpdateDate { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual string UserName { get; protected internal set; }
        public virtual Guid UserTypeId { get; protected internal set; }


        public IEnumerable<IUserRole> UserRoles { get; private set; }

        public void Add(IRole role)
        {
            if (role == null) return;

            var userRole = _listedUserRoles.FirstOrDefault(x => Equals(x.Role, role));
            if (userRole != null) return;

            userRole = new UserRole(this, role);
            _listedUserRoles.Add(userRole);
        }
    }
}
