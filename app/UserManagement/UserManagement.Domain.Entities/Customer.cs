using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {

        public string CustomerName { get; set; }
        public string AccountOwnerName { get; set; }
        public Guid? CustomerProfileId { get; set; }
        public Guid? ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }

        public Customer()
        {
            UserLinkedToCustomer = new HashSet<UserLinkedToCustomer>();
        }

    }
}
