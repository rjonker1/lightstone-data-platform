using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class AccountMeta : Entity
    {
        public virtual string AccountNumber { get; set; }
        public virtual string AccountOwner { get; set; }
        public virtual string BankAccountName { get; set; }
        public virtual int AccountType { get; set; }
        public virtual int BranchCode { get; set; }
        public virtual string BankAccountNumber { get; set; }
        public virtual string BillingType { get; set; }
        public virtual string PaymentType { get; set; }

        public AccountMeta()
        {
        }
    }
}