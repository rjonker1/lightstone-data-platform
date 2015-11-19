using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Core.Security;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {
        public virtual string ContactNumber { get; protected internal set; }
        [Unique]
        public virtual string UserName { get; protected internal set; }
        public virtual string Password { get; protected internal set; }
        public virtual string Salt { get; protected internal set; }
        public virtual Guid? ResetPasswordToken { get; protected internal set; }
        public virtual ActivationStatusType ActivationStatusType { get; protected internal set; }
        public virtual bool? IsActive { get; protected internal set; }
        public virtual bool IsLocked { get; protected internal set; }
        public virtual DateTime? TrialExpiration { get; protected internal set; }
        public virtual UserType UserType { get; protected internal set; }
        public virtual ISet<Role> Roles { get; protected internal set; }
        public virtual ISet<CustomerUser> CustomerUsers { get; protected internal set; }
        public virtual Individual Individual { get; protected internal set; }

        [DoNotMap]
        public virtual string FullName
        {
            get
            {
                return Individual != null ? Individual.FullName : "";
            }
        }

        [DoNotMap]
        public virtual IEnumerable<Customer> Customers
        {
            get
            {
                return CustomerUsers != null
                    ? CustomerUsers.Where(x => x.Customer != null).Select(x => x.Customer).ToList()
                    : Enumerable.Empty<Customer>();
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

        [DoNotMap]
        public virtual IEnumerable<Package> Packages
        {
            get
            {
                return Contracts.SelectMany(x => x.Packages);
            }
        }

        public User() { }

        public User(string firstName, string lastName, string idNumber, string contactNumber, string userName,
            string password,
            bool? isActive, UserType userType, HashSet<Role> roles, Guid id = new Guid())
            : base(id)
        {
            Individual = new Individual(firstName, lastName, idNumber);
            ContactNumber = contactNumber;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            UserType = userType;
            Roles = roles;
        }

        public virtual void HashPassword(string password)
        {
            string hash;
            string salt;
            new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
            Password = hash;
            Salt = salt;
        }

        public virtual bool ValidatePassword(string password)
        {
            return new SaltedHash().VerifyHashString(password, Password, Salt);
        }

        public virtual Guid AssignResetPasswordToken()
        {
            ResetPasswordToken = Guid.NewGuid();
            return ResetPasswordToken.Value;
        }

        public virtual void ClearResetPasswordToken()
        {
            ResetPasswordToken = null;
        }

        public virtual void Activate(bool activate)
        {
            IsActive = activate;
        }

        public virtual void Lock(bool @lock)
        {
            IsLocked = @lock;
        }
    }
}