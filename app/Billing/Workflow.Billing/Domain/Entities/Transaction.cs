using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class Transaction : Entity
    {
        public virtual DateTime Date { get; protected internal set; }
        public virtual Guid PackageId { get; protected internal set; }
        public virtual int PackageVersion { get; protected internal set; }
        public virtual double PackageCostPrice { get; protected internal set; }
        public virtual double PackageRecommendedPrice { get; protected internal set; }
        public virtual Guid ContractId { get; protected internal set; }
        public virtual int ContractVersion { get; protected internal set; }
        public virtual Guid UserId { get; protected internal set; }
        public virtual Guid RequestId { get; protected internal set; }
        public virtual string System { get; protected internal set; }
        public virtual string Server { get; protected internal set; }
        public virtual string State { get; protected internal set; }
        public virtual int StateId { get; protected internal set; }
        public virtual string AccountNumber { get; protected set; }

        public Transaction() { }

        public Transaction(DateTime date, Guid packageId, int packageVersion, double packageCostPrice, double packageRecommendedPrice, Guid contractId, int contractVersion, Guid userId, Guid requestId, string system, string server, string state, int stateId, string accountNumber)
        {
            Date = date;
            PackageId = packageId;
            PackageVersion = packageVersion;
            PackageCostPrice = packageCostPrice;
            PackageRecommendedPrice = packageRecommendedPrice;
            ContractId = contractId;
            ContractVersion = contractVersion;
            UserId = userId;
            RequestId = requestId;
            System = system;
            Server = server;
            State = state;
            StateId = stateId;
            AccountNumber = accountNumber;
        }
    }

}
