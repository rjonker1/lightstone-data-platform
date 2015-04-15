using System;
using System.Collections;
using System.Collections.Generic;

namespace Workflow.Billing.Domain.Entities
{
    public class MockTransaction : MockProduct
    {
        public virtual Guid TransactionId { get; protected internal set; }
    }
}