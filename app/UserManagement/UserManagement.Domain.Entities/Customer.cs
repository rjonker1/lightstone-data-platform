using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {

        public virtual string CustomerName { get; set; }
        public virtual string AccountOwnerName { get; set; }
        public virtual Guid? CustomerProfileId { get; set; }
        public virtual Guid? ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }

        public Customer()
        {
            UserLinkedToCustomer = new HashSet<UserLinkedToCustomer>();
        }

    }
}
