using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages.BillingRun
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class BillingMessage : Entity
    {
        public virtual string RunType { get; set; }
        public virtual DateTime Schedule { get; set; }

        public BillingMessage()
        {
        }
    }
}