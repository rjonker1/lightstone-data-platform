using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual string UserName { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual bool? IsActive { get; protected internal set; }
        public virtual UserType UserType { get; protected internal set; }
        public virtual ISet<Role> Roles { get; protected internal set; }
        //public virtual IEnumerable<ClientUser> ClientUsers { get; protected internal set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }

        public User() { }

        public User(string firstName, string lastName, string idNumber, string contactNumber, string userName, string password, 
            bool? isActive, UserType userType, HashSet<Role> roles, Guid id = new Guid())
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            ContactNumber = contactNumber;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            UserType = userType;
            Roles = roles;
        }

        //public User(string password, string userName, bool? isActive,
        //                //IEnumerable<ClientUser> clientUsers, 
        //                UserType userType, 
        //                IEnumerable<Customer> customers, 
        //                IList<Role> roles, Guid id =  new Guid()): base(id)
        //{

        //    Password = password;
        //    UserName = userName;
        //    IsActive = isActive;
        //    //ClientUsers = new Collection<ClientUser>();
        //    UserType = userType;
        //    //Customers = customers;
        //    Roles = roles;
        //}
    }
}


