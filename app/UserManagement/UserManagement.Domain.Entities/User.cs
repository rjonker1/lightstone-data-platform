using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Core.Security;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string ContactNumber { get; set; }
        [Unique]
        public virtual string UserName { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual string Salt { get; protected internal set; }
        public virtual ActivationStatusType ActivationStatusType { get; protected internal set; }
        public virtual bool? IsActive { get; set; }
        public virtual bool IsLocked { get; set; }
        public virtual DateTime? TrialExpiration { get; set; }
        public virtual UserType UserType { get; protected internal set; }
        public virtual ISet<Role> Roles { get; protected internal set; }
        public virtual ISet<CustomerUser> CustomerUsers { get; protected internal set; }
        [DoNotMap]
        public virtual IEnumerable<Customer> Customers
        {
            get
            {
                return CustomerUsers != null ? CustomerUsers.Where(x => x.Customer != null).Select(x => x.Customer).ToList() : Enumerable.Empty<Customer>();
            }
            set
            {
                CustomerUsers = new HashSet<CustomerUser>(value.Select(x => new CustomerUser(x, this, false)).ToList());
            }
        }
        [DoNotMap]
        public virtual IEnumerable<Client> Clients
        {
            get
            {
                return Customers.SelectMany(x => x.Clients);
            }
        } 
        public virtual ISet<ClientUserAlias> ClientUserAliases { get; protected internal set; }

        [DoNotMap]
        public virtual IEnumerable<Contract> Contracts
        {
            get
            {
                var customerContracts = Customers.SelectMany(c => c.Contracts);
                var clientContracts = Customers.SelectMany(c => c.Clients.SelectMany(client => client.Contracts));
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