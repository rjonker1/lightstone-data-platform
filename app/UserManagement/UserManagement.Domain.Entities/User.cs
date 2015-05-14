using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Core.Security;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string ContactNumber { get; set; }
        [DomainSignature]
        public virtual string UserName { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual string Salt { get; protected internal set; }
        public virtual bool? IsActive { get; set; }
        public virtual UserType UserType { get; protected internal set; }
        public virtual ISet<Role> Roles { get; protected internal set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }
        public virtual ISet<ClientUser> ClientUsers { get; protected internal set; }

        [DoNotMap]
        public virtual IEnumerable<Client> Clients
        {
            get
            {
                return ClientUsers != null ? ClientUsers.Select(x => x.Client) : Enumerable.Empty<Client>();
            }
        }
        [DoNotMap]
        public virtual IEnumerable<Contract> Contracts
        {
            get
            {
                var customerContracts = Customers.SelectMany(x => x.Contracts);
                var clientContracts = Clients.SelectMany(x => x.Contracts);
                return customerContracts.Union(clientContracts);
            }
        } 
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

        public virtual void HashPassword()
        {
            string hash;
            string salt;
            new SaltedHash().GetHashAndSaltString(Password, out hash, out salt);
            Password = hash;
            Salt = salt;
        }
    }
}