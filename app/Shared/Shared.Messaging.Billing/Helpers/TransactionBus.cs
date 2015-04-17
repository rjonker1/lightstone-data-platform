using System;
using System.Collections.Generic;
using EasyNetQ;
using EasyNetQ.Topology;

namespace DataPlatform.Shared.Messaging.Billing.Helpers
{
    public class TransactionBus
    {
        private readonly IAdvancedBus advancedBus;
        private IExchange exchange;
        private IQueue queue;

        public TransactionBus(IAdvancedBus bus)
        {
            advancedBus = bus;
        }

        public void RegisterQueuesExchanges<T>(IEnumerable<T> messageTypes)
        {
            foreach (var messageType in messageTypes)
            {
                var attrs = Attribute.GetCustomAttributes(messageType.GetType());

                foreach (Attribute attr in attrs)
                {
                    if (attr is QueueAttribute)
                    {
                        var messageQueueAttribute = (QueueAttribute)attr;

                        var exchangeName = messageQueueAttribute.ExchangeName;
                        var queueName = messageQueueAttribute.QueueName;

                        exchange = advancedBus.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
                        queue = advancedBus.QueueDeclare(queueName);
                        advancedBus.Bind(exchange, queue, "");
                    }
                }
            }
        }

        private IExchange BuildMessageQueueExchange<T>(T messageType)
        {
            var exchangeName = "";
            var queueName = "";

            var attrs = Attribute.GetCustomAttributes(messageType.GetType());

            foreach (Attribute attr in attrs)
            {
                if (attr is QueueAttribute)
                {
                    var messageQueueAttribute = (QueueAttribute)attr;

                    exchangeName = messageQueueAttribute.ExchangeName;
                    queueName = messageQueueAttribute.QueueName;

                    break;
                }
            }

            exchange = advancedBus.ExchangeDeclare(exchangeName.Length > 0 ? exchangeName : "DEFAULTED_NAME", ExchangeType.Fanout);
            queue = advancedBus.QueueDeclare(queueName.Length > 0 ? queueName : "DEFAULTED_NAME");
            advancedBus.Bind(exchange, queue, "");

            return exchange;
        }

        public void SendDynamic<T>(T message) where T : class
        {
            var publishToExchange = BuildMessageQueueExchange(message);
            advancedBus.Publish<T>(publishToExchange, "", true, false, new Message<T>(message));
        }

        public void Send<T>(T message, string exchangeName, string queueName) where T : class
        {
            exchange = advancedBus.ExchangeDeclare(exchangeName.Length > 0 ? exchangeName : "DEFAULTED_NAME", ExchangeType.Fanout);
            queue = advancedBus.QueueDeclare(queueName.Length > 0 ? queueName : "DEFAULTED_NAME");
            advancedBus.Bind(exchange, queue, "");

            advancedBus.Publish<T>(exchange, "", true, false, new Message<T>(message));
        }
    }
}