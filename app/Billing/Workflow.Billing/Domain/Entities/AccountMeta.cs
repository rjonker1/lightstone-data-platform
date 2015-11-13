using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class AccountMeta : Entity
    {
        public virtual string AccountNumber { get; set; }
        public virtual string AccountOwner { get; set; }
        public virtual string BankAccountName { get; set; }
        public virtual int AccountType { get; set; }

        public virtual string BillingAccountContactEmail { get; set; }
        public virtual string BillingAccountContactName { get; set; }
        public virtual string BillingAccountContactNumber { get; set; }
        public virtual string BillingCompanyRegistration { get; set; }
        public virtual string BillingDebitOrderAccountNumber { get; set; }
        public virtual string BillingDebitOrderAccountOwner { get; set; }
        public virtual string BillingDebitOrderBranchCode { get; set; }
        public virtual string BillingDebitOrderDate { get; set; }
        public virtual string BillingPastelId { get; set; }
        public virtual string BillingPaymentType { get; set; }
        public virtual string BillingType { get; set; }
        public virtual string BillingVatNumber { get; set; }

        public AccountMeta()
        {
        }
    }
}