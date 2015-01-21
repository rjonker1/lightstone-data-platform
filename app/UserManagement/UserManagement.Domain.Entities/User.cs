﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserManagement.Domain.Core.Entities;
//using IUserType = UserManagement.Domain.Entities.IUserType;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {

        public virtual DateTime FirstCreateDate { get; set; }
        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserName { get; set; }
        public virtual Guid UserTypeId { get; set; }
        public virtual bool? IsActive { get; set; }

        public virtual ICollection<ClientUser> ClientUser { get; set; }

        //TODO: Implement UserType mapping
        //public virtual IEnumerable<UserType> UserType { get; set; }
        public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }

        protected User() { }

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

            ClientUser = new Collection<ClientUser>();
            //UserType = new UserType(userTypeId, "User"); 
            UserLinkedToCustomer = new Collection<UserLinkedToCustomer>();
            UserProfile = new Collection<UserProfile>();
            UserRole = new Collection<UserRole>();
        }
    }
}


