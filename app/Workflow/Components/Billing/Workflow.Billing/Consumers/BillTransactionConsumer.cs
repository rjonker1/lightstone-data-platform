using System;
using System.Data;
using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Messages;

namespace Workflow.Billing.Consumers
{
    public class BillTransactionConsumer : IConsume<BillTransactionMessage>
    {
        private readonly IDbConnection connection;
        private static readonly ILog log = LogManager.GetLogger<BillTransactionConsumer>();

        public BillTransactionConsumer()
        {
            this.connection = connection;
        }

        public void Consume(BillTransactionMessage message)
        {
            

        }
    }
}
