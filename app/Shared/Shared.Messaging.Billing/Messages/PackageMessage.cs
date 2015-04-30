using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class PackageMessage : Entity
    {
        public virtual Guid PackageId { get; set; }
        public virtual string PackageName { get; set; }

        public PackageMessage()
        {
        }
    }
}