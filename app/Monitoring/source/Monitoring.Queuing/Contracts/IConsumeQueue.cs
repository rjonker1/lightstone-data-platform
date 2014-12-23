using System;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.RabbitMq;
using RabbitMQ.Client;

namespace Monitoring.Queuing.Contracts
{
    public interface IConsumeQueue
    {
        IModel Model { get; set; }
        IConnection Connection { get; }
        string QueueName { get; }

        void ReadFromQueue(Action<string, RabbitConsumer, ulong> onDequeue,
            Action<Exception, RabbitConsumer, ulong> onError, string exchangeName, string queueName,
            string routingKeyName, string exchangeType);

        void AddBindingToAQueue(MonitoringQueue bindingToQueue, string queueName, string exchangeName,
            string routingKeyName, string exchangeType);

        void AddExchangeBindingToQueue(MonitoringQueue bindingToQueue, string exchangeName,
            string routingKeyName);

        void PurgeQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        void DeleteQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        void AddQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        int MessageCount(string queueName, string exchangeName, string routingKeyName, string exchangeType);
        void DeleteExchange(string exchangeName, string exchangeType);
        void AddExchange(string exchangeName, string exchangeType);
    }
}