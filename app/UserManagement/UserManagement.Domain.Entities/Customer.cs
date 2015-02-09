using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public virtual string CustomerName { get; protected internal set; }
        public virtual string AccountOwnerName { get; protected internal set; }
        public virtual Billing Billing { get; protected internal set; }
        public virtual CommercialState CommercialState { get; protected internal set; }
        public virtual CreateSource CreateSource { get; protected internal set; }
        public virtual PlatformStatus PlatformStatus { get; protected internal set; }
        public virtual ProfileDetail ProfileDetail { get; protected internal set; }
        //public virtual Province Province { get; protected internal set; }
        //public virtual CustomerProfile CustomerProfile { get; set; }
        //public virtual IList<User> Users { get; protected internal set; }

        protected Customer() { }

        public Customer(Guid id, string customerName, string accountOwnerName, CommercialState commercialState, 
            CreateSource createSource, PlatformStatus platformStatus)
            : base(id)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
        }

        public virtual void UpdateCustomer(string customerName, string accountOwnerName, CommercialState commercialState,
            CreateSource createSource, PlatformStatus platformStatus)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
        }
    }
}
