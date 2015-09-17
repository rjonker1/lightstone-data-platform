using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Customer : NamedEntity
    {
        public virtual User AccountOwner { get; protected internal set; }
        public virtual string Notes { get; protected internal set; }

        private CustomerAccountNumber _customerAccountNumber = new CustomerAccountNumber();
        public virtual CustomerAccountNumber CustomerAccountNumber
        {
            get
            {
                return _customerAccountNumber ?? (_customerAccountNumber = new CustomerAccountNumber());
            }
        }

        public virtual Billing Billing { get; protected internal set; }
        public virtual CommercialState CommercialState { get; protected internal set; }
        private PlatformStatusType _platformStatus;
        public virtual PlatformStatusType PlatformStatus
        {
            get
            {
                var packages = Contracts != null ? Contracts.SelectMany(x => x.Packages != null ? x.Packages.Where(p => p != null) : Enumerable.Empty<Package>()) : Enumerable.Empty<Package>();
                var activated = Contracts != null && (Contracts.Any() && packages.Any());
                _platformStatus = activated ? PlatformStatusType.Activated : PlatformStatusType.Incomplete;
                if (IsLocked) _platformStatus = PlatformStatusType.Locked;
                return _platformStatus;
            }
            set
            {
                _platformStatus = value;
            }
        }

        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual CreateSourceType CreateSource { get; protected internal set; }
        public virtual ISet<CustomerUser> CustomerUsers { get; protected internal set; }
        [DoNotMap]
        public virtual IEnumerable<User> Users
        {
            get
            {
                return CustomerUsers != null ? CustomerUsers.Where(x => x.User != null).Select(x => x.User).ToList() : Enumerable.Empty<User>();
            }
            set
            {
                CustomerUsers = new HashSet<CustomerUser>(value.Select(x => new CustomerUser(this, x, false)).ToList());
            }
        }
        public static class Expressions
        {
            public static readonly Expression<Func<Customer, IEnumerable<User>>> Users = x => x.Users;
        }
        public virtual ISet<Contract> Contracts { get; protected internal set; }
        public virtual ISet<Client> Clients { get; protected internal set; }
        public virtual bool IsLocked { get; protected internal set; }
        public virtual bool IsActive { get; protected internal set; }
        public virtual ISet<CustomerIndustry> Industries { get; protected internal set; }
        public virtual DateTime? TrialExpiration { get; protected internal set; }
        public virtual ISet<CustomerAddress> Addresses { get; protected internal set; }

        protected Customer() { }

        public Customer(string name) : base(name) { }

        public virtual void SetCreateSource(CreateSourceType createSource)
        {
            CreateSource = createSource;
        }

        public virtual void SetAccountOwner(User accountOwner)
        {
            AccountOwner = accountOwner;
        }

        public virtual void Lock(bool @lock)
        {
            IsLocked = @lock;
        }

        public virtual void Activate(bool activate)
        {
            IsActive = activate;
        }
    }
}
