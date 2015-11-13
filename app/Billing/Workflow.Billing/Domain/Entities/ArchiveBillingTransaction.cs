using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class ArchiveBillingTransaction : Entity
    {
        public virtual Guid CustomerId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual Guid ClientId { get; set; }
        public virtual string ClientName { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string BillingType { get; set; }
        public virtual Guid ContractId { get; set; }

        public virtual string Type { get; set; }
        public virtual Guid StageBillingId { get; set; }
        public virtual int BillingId { get; set; }

        public virtual Package Package { get; set; }

        public virtual DataProvider DataProvider { get; set; }

        public virtual UserTransaction UserTransaction { get; set; }

        public virtual User User { get; set; }

        public ArchiveBillingTransaction()
        {
            Created = DateTime.UtcNow;
            Package = new Package();
            DataProvider = new DataProvider();
            UserTransaction = new UserTransaction();
            User = new User();
        }
    }
}