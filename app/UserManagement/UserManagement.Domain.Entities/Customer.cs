using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Customer : NamedEntity
    {
        public virtual User AccountOwner { get; set; }
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
                var activated = Contracts != null && (Contracts.Any() && Contracts.SelectMany(x => x.Packages).Any());
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
        public virtual CreateSourceType CreateSource { get; set; }
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
        public virtual bool IsLocked { get; set; }
        public virtual bool IsActive { get; set; }
		public virtual ISet<CustomerIndustry> Industries { get; set; }
        public virtual DateTime? TrialExpiration { get; set; }

        protected Customer() { }

        public Customer(string name) : base(name)
        {
        }
    }
}
