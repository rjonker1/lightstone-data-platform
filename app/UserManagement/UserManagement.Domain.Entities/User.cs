using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserManagement.Domain.Core.Entities;

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

        public virtual IEnumerable<ClientUser> ClientUsers { get; protected internal set; }

        public virtual UserType UserType { get; protected internal set; }
        public virtual IEnumerable<Customer> Customers { get; protected internal set; }
        public virtual IList<Role> Roles { get; protected internal set; }

        protected User() { }

        public User(Guid id, DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, bool? isActive,
                        //IEnumerable<ClientUser> clientUsers, 
                        UserType userType, 
                        IEnumerable<Customer> customers, 
                        IList<Role> roles): base(id)
        {
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            IsActive = isActive;
            ClientUsers = new Collection<ClientUser>();
            UserType = userType;
            Customers = customers;
            Roles = roles;
        }
    }
}


