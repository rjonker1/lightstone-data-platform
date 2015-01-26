using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public virtual string CustomerName { get; set; }
        public virtual string AccountOwnerName { get; set; }

        public virtual Province Province { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual IList<User> Users { get; set; }

        protected Customer()
        {
            
        }

        public Customer(Guid id, string customerName, string accountOwnerName, Province province, CustomerProfile customerProfile, IList<User> users)
            : base(id)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            Province = province;
            CustomerProfile = customerProfile;
            Users = users;
        }

    }
}
