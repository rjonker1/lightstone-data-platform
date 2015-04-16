using System;
using System.Collections;
using System.Collections.Generic;

namespace Workflow.Billing.Domain.Entities
{
    public class MockTransaction : Product
    {
        public virtual Guid TransactionId { get; set; }
    }
}