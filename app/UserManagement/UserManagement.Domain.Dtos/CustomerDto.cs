using System;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AccountOwnerName { get; set; }
        public Guid CommercialStateId { get; set; }
        public Guid CreateSourceId { get; set; }
        public Guid PlatformStatusId { get; set; }
        public virtual string BillingContactNumber { get; set; }
        public virtual string BillingContractPerson { get; set; }
        public virtual string BillingCompanyRegistration { get; set; }
        public virtual DateTime? BillingDebitOrderDate { get; set; }
        public virtual string BillingPastelId { get; set; }
        public virtual string BillingVatNumber { get; set; }
        public virtual Guid BillingPaymentTypeId { get; set; }
    }
}