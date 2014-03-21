using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Messages;

namespace Workflow.Billing.Consumers
{
    public class BillTransactionConsumer : IConsume<BillTransactionMessage>
    {
        public void Consume(BillTransactionMessage message)
        {
            
        }
    }
}
