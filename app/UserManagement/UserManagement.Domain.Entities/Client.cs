using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Client : NamedEntity, IIndustry
    {
        public virtual User AccountOwner { get; protected internal set; }
        public virtual string Notes { get; protected internal set; }
        private ClientAccountNumber _clientAccountNumber = new ClientAccountNumber();
        public virtual ClientAccountNumber ClientAccountNumber
        {
            get
            {
                return _clientAccountNumber ?? (_clientAccountNumber = new ClientAccountNumber());
            }
        }
        public virtual Billing Billing { get; protected internal set; }
        public virtual CommercialState CommercialState { get; protected internal set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }
        public virtual ISet<Contract> Contracts { get; protected internal set; }
        public virtual ISet<ClientUserAlias> UserAliases { get; protected internal set; }
        public virtual bool IsActive { get; protected internal set; }
        public virtual bool IsLocked { get; protected internal set; }
        public virtual DateTime? TrialExpiration { get; protected internal set; }
        public virtual ISet<ClientIndustry> Industries { get; protected internal set; }
        public virtual Individual Individual { get; protected internal set; }
        public virtual ISet<ClientAddress> Addresses { get; protected internal set; }

        [DoNotMap]
        public virtual IEnumerable<User> Users
        {
            get
            {
                return Customers.SelectMany(c => c.Users);
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

        public Client() { }

        public Client(string clientName) : base(clientName) { }

        public virtual void SetAccountOwner(User accountOwner)
        {
            AccountOwner = accountOwner;
        }

        public virtual void Lock(bool @lock)
        {
            IsLocked = @lock;
        }

        public virtual void SetAddress(Address address, AddressType type)
        {
            var customerAddress = Addresses.FirstOrDefault(x => Equals(x.Address, address));
            if (customerAddress == null)
            {
                customerAddress = new ClientAddress(this, address, type);
                Addresses.Add(customerAddress);
            }
            customerAddress.Address = address;
        }
    }
}
