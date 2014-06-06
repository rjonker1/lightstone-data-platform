using System;
using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Messages;

namespace Workflow.Billing.Consumers
{
    public class BillTransactionConsumer : IConsume<BillTransactionMessage>
    {
        private static readonly ILog log = LogManager.GetLogger<BillTransactionConsumer>();

        public BillTransactionConsumer()
        {
        }

        public void Consume(BillTransactionMessage message)
        {
            

        }
    }
}
