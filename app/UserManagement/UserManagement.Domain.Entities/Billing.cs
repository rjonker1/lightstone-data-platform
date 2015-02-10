using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string BillingContactNumber { get; set; }
        public virtual string BillingContractPerson { get; set; }
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }
        public virtual string PastelId { get; set; }
        public virtual string VatNumber { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        protected internal Billing() { }

        public Billing(string billingContactNumber, string billingContractPerson, string companyRegistration, DateTime? debitOrderDate, string pastelId, string vatNumber, PaymentType paymentType, Guid id = new Guid()) : base(id)
        {
            BillingContactNumber = billingContactNumber;
            BillingContractPerson = billingContractPerson;
            CompanyRegistration = companyRegistration;
            DebitOrderDate = debitOrderDate;
            PastelId = pastelId;
            VatNumber = vatNumber;
            PaymentType = paymentType;
        }
    }
}
