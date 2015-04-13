using System;
using CommonDomain;
using CommonDomain.Core;

namespace Workflow.Lace.Domain.Aggregates
{
    public class BillingTransaction : AggregateBase, IAggregate
    {
        private BillingTransaction(Guid id)
        {
            Id = id;
        }

        public BillingTransaction(Guid transactionId, DateTime date) : this(transactionId)
        {
            RaiseEvent(new TransactionMessage);
        }

        public static BillingTransaction CreateTransaction(Guid transactionId, DateTime date)
        {
            return new BillingTransaction();
        }
    }
}
