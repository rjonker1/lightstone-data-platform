using System;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Shared.Messaging.Billing.Helpers
{
    public class TransactionBus
    {
        private readonly IAdvancedBus advancedBus;

        public TransactionBus(IAdvancedBus bus)
        {
            advancedBus = bus;
        }

        public void Send<T>(T message, string exchangeName, string queueName) where T : class
        {
            var exchange = advancedBus.ExchangeDeclare( exchangeName.Length > 0 ? exchangeName : "DEFAULTED_NAME", ExchangeType.Fanout);
            var queue = advancedBus.QueueDeclare(queueName);
            advancedBus.Bind(exchange, queue, "");

            advancedBus.Publish<T>(exchange, "", true, false, new Message<T>(message));
        } 
    }
}