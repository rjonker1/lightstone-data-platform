using Workflow.Lace.Shared.Queuing;

namespace Workflow.Lace.Shared.QueueSetup
{
    public class Queue : IAmAQueue
    {
        public Queue(string name, string exchangeName, string routingKey, string exchangeType,
            QueueFunction queueFunction, QueueType queueType)
        {
            QueueName = name;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
            ExchangeType = exchangeType;
            QueueFunction = queueFunction;
            QueueType = queueType;
        }

        public string QueueName { get; private set; }

        public string ExchangeName { get; private set; }

        public string RoutingKey { get; private set; }

        public string ExchangeType { get; private set; }

        public QueueFunction QueueFunction { get; private set; }

        public QueueType QueueType { get; private set; }
    }
}
