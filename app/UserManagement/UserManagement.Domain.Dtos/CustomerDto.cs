using System;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            //BillingDto = new BillingDto();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AccountOwnerName { get; set; }
        public Guid CommercialStateId { get; set; }
        public Guid CreateSourceId { get; set; }
        public Guid PlatformStatusId { get; set; }
        public BillingDto BillingDto { get; set; }
    }

    public class BillingDto
    {
        public virtual string ContactNumber { get; set; }
        public virtual string ContractPerson { get; set; }
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }
        public virtual string PastelId { get; set; }
        public virtual string VatNumber { get; set; }
        public virtual Guid PaymentTypeId { get; set; }
    }
}