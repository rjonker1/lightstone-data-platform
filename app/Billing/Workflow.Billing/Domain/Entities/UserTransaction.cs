using System;

namespace Workflow.Billing.Domain.Entities
{
    public interface IUserTransaction
    {
        Guid TransactionId { get; set; }
        Guid RequestId { get; set; }
        bool IsBillable { get; set; }
    }

    public class UserTransaction : Package, IUserTransaction
    {
        public virtual Guid TransactionId { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual bool IsBillable { get; set; }
    }
}