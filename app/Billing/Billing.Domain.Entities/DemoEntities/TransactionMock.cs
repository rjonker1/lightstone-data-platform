using System;
using System.Collections.Generic;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class TransactionMocks : Entity
    {
        public virtual string TransactionDetail { get; protected internal set; }
        public virtual string State { get; protected internal set; }
        public virtual Product Product { get; protected internal set; } 

        public TransactionMocks()
        {
            TransactionDetail = "Trans001";
            State = "Successful";
        }
    }
}