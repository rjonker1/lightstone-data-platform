using System;
using Monitoring.CrossCutting;
using RabbitMQ.Client;

namespace Monitoring.RabbitMq
{
    public interface IConsumeMessagesFromQueue
    {
        IModel Model { get; set; }
        IConnection Connection { get; }
        string QueueName { get; }

        void ReadFromQueue(Action<string, Consumer, ulong> onDequeue,
            Action<Exception, Consumer, ulong> onError, string exchangeName, string queueName,
            string routingKeyName);

        void AddBindingToAQueue(DataProviderQueue bindingToQueue, string queueName, string exchangeName,
            string routingKeyName);

        void PurgeQueue(string queueName, string exchangeName, string routingKeyName);
        void DeleteQueue(string queueName, string exchangeName, string routingKeyName);
        void AddQueue(string queueName, string exchangeName, string routingKeyName);
    }
}