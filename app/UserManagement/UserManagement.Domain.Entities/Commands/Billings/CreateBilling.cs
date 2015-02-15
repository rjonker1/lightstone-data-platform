using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Billings
{
    public class CreateBilling : DomainCommand
    {
        public string BillingContactNumber;
        public string BillingContractPersion;
        public string CompanyRegistration;
        public DateTime? DebitOrderDate;
        public string PastelId;
        public string VatNumber;
        public PaymentType PaymentType;

        public CreateBilling(string billingContactNumber, string billingContractPersion, string companyRegistration, DateTime? debitOrderDate, string pastelId, string vatNumber, PaymentType paymentType)
        {
            Id = Guid.NewGuid();
            BillingContactNumber = billingContactNumber;
            BillingContractPersion = billingContractPersion;
            CompanyRegistration = companyRegistration;
            DebitOrderDate = debitOrderDate;
            PastelId = pastelId;
            VatNumber = vatNumber;
            PaymentType = paymentType;
        }
    }
}