using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {

        public DateTime FirstCreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Guid UserTypeId { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ClientUser> ClientUser { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }

        public User()
        {
            ClientUser = new HashSet<ClientUser>();
            UserLinkedToCustomer = new HashSet<UserLinkedToCustomer>();
            UserProfile = new HashSet<UserProfile>();
            UserRole = new HashSet<UserRole>();
        }

    }
}


