using System;
using System.Collections;
using System.Collections.Generic;

namespace Workflow.Billing.Domain.Entities
{
    public class MockTransaction : Package
    {
        public virtual Guid TransactionId { get; set; }
        public virtual Guid RequestId { get; set; }
    }
}