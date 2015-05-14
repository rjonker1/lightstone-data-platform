using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Billing.Domain.Entities
{
    public class AuditLog : Entity
    {
        public virtual Guid TransactionId { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string OriginalValue { get; set; }
        public virtual string NewValue { get; set; }
    }
}