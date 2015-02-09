using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string BillingContactNumber { get; set; }
        public virtual string BillingContractPersion { get; set; }
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime FirstCreateDate { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }
        public virtual string PastelID { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        //public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        protected Billing() { }

        public Billing(Guid id, string billingContactNumber, string billingContractPersion, string companyRegistration, DateTime firstCreateDate, DateTime? debitOrderDate, PaymentType paymentType)
            : base(id)
        {

            BillingContactNumber = billingContactNumber;
            BillingContractPersion = billingContractPersion;
            CompanyRegistration = companyRegistration;
            FirstCreateDate = firstCreateDate;
            DebitOrderDate = debitOrderDate;
            PaymentType = paymentType;
        }
    }
}
