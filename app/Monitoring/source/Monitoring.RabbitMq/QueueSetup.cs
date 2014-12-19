using Monitoring.CrossCutting;

namespace Monitoring.RabbitMq
{
    public class QueueSetup : ISetupQueues
    {
        private readonly IConsumeMessagesFromQueue _consumer;

        public QueueSetup(IConsumeMessagesFromQueue consumer)
        {
            _consumer = consumer;
        }

        public void AddQueues()
        {
            foreach (var queue in DataProviderQueues.Names)
            {
                _consumer.AddQueue(queue.Name, queue.Exchange, queue.RoutingKey);
            }

            foreach (var queue in DataProviderQueues.QueuesForBinding)
            {
                _consumer.AddBindingToAQueue(queue.BindToQueue, queue.QueueName, queue.ExchangeName, queue.RoutingKey);
            }
        }

        public void DeleteAllQueues()
        {
            foreach (var queue in DataProviderQueues.Names)
            {
                _consumer.DeleteQueue(queue.Name, queue.Exchange, queue.RoutingKey);
            }
        }
    }
}
