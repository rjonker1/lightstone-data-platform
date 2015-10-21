using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class TransactionRequest : Entity
    {
        public virtual Guid RequestId { get; protected internal set; }
        public virtual Guid UserId { get; protected internal set; }
        public virtual int StateId { get; protected internal set; }
        public virtual DataProviderResponseState State { get; protected internal set; }
        public virtual ApiCommitRequestState UserState { get; protected internal set; }
        public virtual DateTime ExpirationDate { get; protected internal set; }

        public TransactionRequest()
        {
            
        }
    }
}