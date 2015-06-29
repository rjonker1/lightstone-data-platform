using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class ContractMessage : Entity
    {
        public virtual string ContractName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool HasPackagePriceOverride { get; set; }
        public virtual Guid ContractBundleId { get; set; }
        public virtual string ContractBundleName { get; set; }
        public virtual double ContractBundlePrice { get; set; }
        public virtual int ContractBundleTransactionLimit { get; set; }
    }
}