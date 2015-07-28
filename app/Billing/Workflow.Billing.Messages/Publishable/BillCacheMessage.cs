using System;
using EasyNetQ;

namespace Workflow.Billing.Messages.Publishable
{
    [Queue("DataPlatform.Cache.Billing", ExchangeName = "DataPlatform.Cache.Billing")]
    public class BillCacheMessage
    {
        public virtual Type BillingType { get; set; }
        public virtual BillingCacheCommand Command { get; set; }
    }

    public enum BillingCacheCommand
    {
        Flush,
        Reload
    }
}