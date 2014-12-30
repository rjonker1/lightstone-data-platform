using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity//, IUser
    {

        //private readonly IList<IUserRole> _listedUserRoles = new List<IUserRole>();

        public User()
        {
            ClientUser = new HashSet<ClientUser>();
            UserLinkedToCustomer = new HashSet<UserLinkedToCustomer>();
            UserRole = new HashSet<UserRole>();
        }

        public DateTime FirstCreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Guid UserTypeId { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual AccountOwner AccountOwner { get; set; }
        public virtual ICollection<ClientUser> ClientUser { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }

        //public IEnumerable<IUserRole> UserRoles { get; private set; }
        //public IEnumerable<IClientUser> ClientUsers { get; private set; }

        //public void Add(IRole role)
        //{
        //    if (role == null) return;

        //    var userRole = _listedUserRoles.FirstOrDefault(x => Equals(x.Role, role));
        //    if (userRole != null) return;

        //    userRole = new UserRole(this, role);
        //    _listedUserRoles.Add(userRole);
        //}
    }
}


