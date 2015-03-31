using System;
using Workflow.Transactions.Shared.Queuing;
using Workflow.Transactions.Shared.Configuration;

namespace Workflow.Transactions.Shared.RabbitMq
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
            foreach (var queue in TransactionQueues.Names)
            {
                _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
            }

            foreach (var queue in TransactionQueues.QueuesForBinding)
            {
                _consumer.AddExchangeBindingToQueue(queue.Queue, queue.ExchangeName, queue.RoutingKey);
            }
        }

        public void PurgeAllQueues()
        {
            foreach (var queue in TransactionQueues.Names)
            {
                _consumer.PurgeQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
            }
        }

        public void DeleteAllQueues()
        {
            foreach (var queue in TransactionQueues.Names)
            {
                _consumer.DeleteQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
            }
        }

        public int GetMessageCount(string exchangeName, string queueName, string routingKey, string exchangeType)
        {
            return _consumer.MessageCount(queueName, exchangeName, routingKey, exchangeType);
        }

        public void DeleteAllExchanges()
        {
            foreach (var exchange in ConfigureTransactionExchanges.ForEvents())
            {
                _consumer.DeleteExchange(exchange.ExchangeName, exchange.ExchangeType);
            }
        }


        public void AddAllExchanges()
        {
            foreach (var exchange in ConfigureTransactionExchanges.ForEvents())
            {
                _consumer.AddExchange(exchange.ExchangeName, exchange.ExchangeType);
            }
        }
    }
}
