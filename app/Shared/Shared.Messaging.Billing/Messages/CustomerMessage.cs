using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class CustomerMessage : Entity
    {
        public virtual string AccountNumber { get; set; }
        public virtual string AccountOwner { get; set; }
        public virtual string BillingType { get; set; }
        public virtual string PaymentType { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual string CustomerName { get; set; }

        public CustomerMessage()
        {
        }
    }
}