using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserManagement.Domain.Core.Entities;
//using IUserType = UserManagement.Domain.Entities.IUserType;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {

        public virtual DateTime FirstCreateDate { get; protected internal set; }
        public virtual string LastUpdateBy { get; protected internal set; }
        public virtual DateTime LastUpdateDate { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual string UserName { get; protected internal set; }
        public virtual bool? IsActive { get; protected internal set; }

        public virtual IEnumerable<ClientUser> ClientUser { get; protected internal set; }

        //TODO: Implement UserType mapping
        public virtual UserType UserType { get; protected internal set; }
        public virtual IEnumerable<UserLinkedToCustomer> UserLinkedToCustomer { get; protected internal set; }
        public virtual IEnumerable<UserProfile> UserProfile { get; protected internal set; }
        public virtual IList<Role> Roles { get; protected internal set; }

        protected User() { }

        public User(Guid id, DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, bool? isActive,
                            IEnumerable<ClientUser> clientUser, UserType userType, IEnumerable<UserLinkedToCustomer> userLinkedToCustomer, IEnumerable<UserProfile> userProfile, IList<Role> roles): base(id)
        {
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            IsActive = isActive;
            ClientUser = clientUser;
            UserType = userType;
            UserLinkedToCustomer = userLinkedToCustomer;
            UserProfile = userProfile;
            Roles = roles;
        }
    }
}


