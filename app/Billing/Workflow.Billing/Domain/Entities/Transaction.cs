using System;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class Transaction : Entity
    {
        public virtual DateTime Date { get; protected internal set; }
        public virtual Guid PackageId { get; protected internal set; }
        public virtual int PackageVersion { get; protected internal set; }
        public virtual Guid ContractId { get; protected internal set; }
        public virtual int ContractVersion { get; protected internal set; }
        public virtual Guid UserId { get; protected internal set; }
        public virtual Guid RequestId { get; protected internal set; }
        public virtual string System { get; protected internal set; }
        public virtual string Server { get; protected internal set; }
        public virtual string State { get; protected internal set; }
        public virtual int StateId { get; protected internal set; }
        public virtual string AccountNumber { get; protected internal set; }

        public Transaction() { }
    }

}
