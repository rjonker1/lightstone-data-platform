using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Customer : NamedEntity
    {
        public virtual User AccountOwner { get; protected internal set; }
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
        public virtual Individual Individual { get; protected internal set; }
        public virtual ISet<CustomerAddress> Addresses { get; protected internal set; }
        public virtual ISet<CustomerNote> CustomerNotes { get; protected internal set; }

        [DoNotMap]
        public virtual IEnumerable<Note> Notes
        {
            get
            {
                return CustomerNotes.Select(x => x.Note);
            }
        }

        [DoNotMap]
        public virtual bool HasNotes
        {
            get
            {
                return Notes.Any();
            }
        }

        [DoNotMap]
        public virtual Address PhysicalAddress
        {
            get
            {
                var customerAddress = Addresses.FirstOrDefault(x => x.AddressType == AddressType.Physical);
                return customerAddress != null ? customerAddress.Address : null;
            }
        }
        [DoNotMap]
        public virtual Address PostalAddress
        {
            get
            {
                var customerAddress = Addresses.FirstOrDefault(x => x.AddressType == AddressType.Postal);
                return customerAddress != null ? customerAddress.Address : null;
            }
        }

        protected Customer() { }

        public Customer(string name) : base(name) { }
        public Customer(string name, Guid id = new Guid()) : base(name, id) { }

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

        public virtual void SetAddress(Address address, AddressType type)
        {
            if (address == null) return;

            Addresses = Addresses ?? new HashSet<CustomerAddress>();
            var customerAddress = Addresses.FirstOrDefault(x => Equals(x.Address, address));
            if (customerAddress == null)
            {
                customerAddress = new CustomerAddress(this, address, type);
                Addresses.Add(customerAddress);
            }
            customerAddress.Address = address;
        }
    }
}
