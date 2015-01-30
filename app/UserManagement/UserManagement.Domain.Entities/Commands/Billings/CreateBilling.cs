using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Billings
{
    public class CreateBilling : DomainCommand
    {

        public string BillingContactNumber;
        public string BillingContractPersion;
        public string CompanyRegistration;
        public DateTime FirstCreateDate;
        public DateTime? DebitOrderDate;

        public PaymentType PaymentType;

        public CreateBilling(string billingContactNumber, string billingContractPersion, string companyRegistration, DateTime firstCreateDate, DateTime? debitOrderDate, PaymentType paymentType)
        {
            Id = Guid.NewGuid();
            BillingContactNumber = billingContactNumber;
            BillingContractPersion = billingContractPersion;
            CompanyRegistration = companyRegistration;
            FirstCreateDate = firstCreateDate;
            DebitOrderDate = debitOrderDate;
            PaymentType = paymentType;
        }
    }
}