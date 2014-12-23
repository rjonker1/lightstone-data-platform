using System;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.Contracts;

namespace Monitoring.Queuing.RabbitMq
{
    public class QueueActions : IHaveQueueActions
    {
        private readonly IConsumeQueue _consumer;

        public QueueActions(IConsumeQueue consumer)
        {
            _consumer = consumer;
        }

        public void ProcessQueue(string exchangeName, string queueName, string routingKey, string exchangeType)
        {
            _consumer.ReadFromQueue(ProcessMessage, RaiseException, exchangeName, queueName, routingKey, exchangeType);
        }

        private static void ProcessMessage(string message, IConsumeQueue consumer, ulong deliveryTag)
        {
            throw new NotImplementedException();
        }
        private static void RaiseException(Exception ex, IConsumeQueue consumer, ulong deliveryTag)
        {
            throw new NotImplementedException();
        }

        public void AddAllQueues()
        {
            foreach (var queue in MonitoringQueues.Names)
            {
                _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
            }

            foreach (var queue in MonitoringQueues.QueuesForBinding)
            {
                _consumer.AddBindingToAQueue(queue.Queue, queue.QueueName, queue.ExchangeName, queue.RoutingKey,
                    queue.Queue.ExchangeType);
            }
        }

        public void PurgeAllQueues()
        {
            foreach (var queue in MonitoringQueues.Names)
            {
                _consumer.PurgeQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
            }
        }

        public void DeleteAllQueues()
        {
            foreach (var queue in MonitoringQueues.Names)
            {
                _consumer.DeleteQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
            }
        }

        public int GetMessageCount(string exchangeName, string queueName, string routingKey, string exchangeType)
        {
            return _consumer.MessageCount(queueName, exchangeName, routingKey, exchangeType);
        }
    }
}
