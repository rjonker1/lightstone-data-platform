using System;
using System.Collections.Generic;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class Product : Entity
    {
        public virtual string ProductName { get; set; }
        public virtual IEnumerable<TransactionMocks> Transactions { get; protected internal set; }

        public Product() { }
    }
}