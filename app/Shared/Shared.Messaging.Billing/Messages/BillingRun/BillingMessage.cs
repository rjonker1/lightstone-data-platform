using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages.BillingRun
{
    [Queue("DataPlatform.Transactions.BillingRun", ExchangeName = "DataPlatform.Transactions.BillingRun")]
    public class BillingMessage : Entity
    {
        public virtual string RunType { get; set; }
        public virtual DateTime? Schedule { get; set; }

        public BillingMessage()
        {
        }
    }
}