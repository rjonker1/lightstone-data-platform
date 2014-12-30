using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class PaymentType : Entity
    {
        public PaymentType()
        {
            Billing = new HashSet<Billing>();
        }

        public string Value { get; set; }

        public virtual ICollection<Billing> Billing { get; set; }
    }
}
