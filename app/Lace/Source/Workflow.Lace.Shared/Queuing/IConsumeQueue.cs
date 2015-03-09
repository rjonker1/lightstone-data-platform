using System;
using RabbitMQ.Client;
using Workflow.Lace.Shared.RabbitMq;

namespace Workflow.Lace.Shared.Queuing
{
    public interface IConsumeQueue
    {
        IModel Model { get; set; }
        IConnection Connection { get; }
        string QueueName { get; }
        void Connect(string hostName, string username, string password, bool useCredentials = false);

        void ReadFromQueue(Action<string, RabbitConsumer, ulong> onDequeue,
            Action<Exception, RabbitConsumer, ulong> onError, string exchangeName, string queueName,
            string routingKeyName, string exchangeType);

        void AddBindingToAQueue(IAmAQueue bindingToQueue, string queueName, string exchangeName,
            string routingKeyName, string exchangeType);

        void AddExchangeBindingToQueue(IAmAQueue bindingToQueue, string exchangeName,
            string routingKeyName);

        void PurgeQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        void DeleteQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        void AddQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        int MessageCount(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        void DeleteExchange(string exchangeName, string exchangeType);
        void AddExchange(string exchangeName, string exchangeType);
    }
}
