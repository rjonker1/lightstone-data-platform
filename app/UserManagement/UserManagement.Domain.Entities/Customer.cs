using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public virtual string CustomerName { get; protected internal set; }
        public virtual string AccountOwnerName { get; protected internal set; }
        public virtual Billing Billing { get; set; }
        public virtual CommercialState CommercialState { get; set; }
        public virtual CreateSource CreateSource { get; set; }
        public virtual PlatformStatus PlatformStatus { get; set; }
        public virtual ProfileDetail ProfileDetail { get; set; }
        public virtual Province Province { get; protected internal set; }
        //public virtual CustomerProfile CustomerProfile { get; set; }
        //public virtual IList<User> Users { get; protected internal set; }

        protected Customer() { }

        public Customer(Guid id, string customerName, string accountOwnerName, Province province 
            //CustomerProfile customerProfile, IList<User> users
            )
            : base(id)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            Province = province;
            //CustomerProfile = customerProfile;
            //Users = users;
        }

        public virtual void UpdateCustomer(string customerName, string accountOwnerName, Province province)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            Province = province;
        }
    }
}
