using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            UserLinkedToCustomer = new HashSet<UserLinkedToCustomer>();
        }

        public string CustomerName { get; set; }
        public Nullable<Guid> AccountOwnerId { get; set; }
        public Nullable<Guid> CustomerProfileId { get; set; }
        public Nullable<Guid> ProvinceId { get; set; }

        public virtual AccountOwner AccountOwner { get; set; }
        public virtual Province Province { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual ICollection<UserLinkedToCustomer> UserLinkedToCustomer { get; set; }
    }
}
