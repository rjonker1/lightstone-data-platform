using System;

namespace Workflow.Billing.Domain.Entities
{
    public class UserTransaction : Package
    {
        public virtual DateTime? Created { get; set; }
        public virtual Guid TransactionId { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual bool IsBillable { get; set; }
    }
}