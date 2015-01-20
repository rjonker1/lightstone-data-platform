using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {

        public virtual string BillingContactNumber { get; set; }
        public virtual string BillingContractPersion { get; set; }
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime FirstCreateDate { get; set; }
        public virtual Guid PaymentTypeId { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        public Billing()
        {
            CustomerProfile = new HashSet<CustomerProfile>();
        }

    }
}
