using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {

        public string BillingContactNumber { get; set; }
        public string BillingContractPersion { get; set; }
        public string CompanyRegistration { get; set; }
        public DateTime FirstCreateDate { get; set; }
        public Guid PaymentTypeId { get; set; }
        public DateTime? DebitOrderDate { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        public Billing()
        {
            CustomerProfile = new HashSet<CustomerProfile>();
        }

    }
}
