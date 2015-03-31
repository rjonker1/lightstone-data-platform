using Workflow.Transactions.Shared.Queuing;

namespace Workflow.Transactions.Shared.QueueSetup
{
    public class BindToQueue : IBindToAQueue
    {

        public BindToQueue(IAmAQueue bindToQueue, string queueName, string exchangeName, string routingKey)
        {
            Queue = bindToQueue;
            QueueName = queueName;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
        }

        public IAmAQueue Queue { get; private set; }
        public string QueueName { get; private set; }
        public string ExchangeName { get; private set; }
        public string RoutingKey { get; private set; }
    }
}
