using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity, INamedEntity
    {

        public virtual DateTime FirstCreateDate { get; set; }
        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserName { get; set; }
        public virtual Guid UserTypeId { get; set; }
        public virtual bool? IsActive { get; set; }

        //public virtual ICollection<ClientUser> ClientUser { get; set; }
        //public virtual UserType UserType { get; set; }
        //public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }
        //public virtual ICollection<UserProfile> UserProfile { get; set; }
        //public virtual ICollection<UserRole> UserRole { get; set; }

        protected User() { }

        //public User()
        //{
        //    ClientUser = new HashSet<ClientUser>();
        //    UserLinkedToCustomer = new HashSet<UserLinkedToCustomer>();
        //    UserProfile = new HashSet<UserProfile>();
        //    UserRole = new HashSet<UserRole>();
        //}

        public User(DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, Guid userTypeId, bool? isActive)
        {
            Id = Guid.NewGuid();
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            UserTypeId = userTypeId;
            IsActive = isActive;
        }

        public virtual string Name { get; set; }
    }
}


