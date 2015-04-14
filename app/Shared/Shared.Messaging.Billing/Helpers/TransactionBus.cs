using System;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Shared.Messaging.Billing.Helpers
{
    public class TransactionBus
    {
        //private readonly IAdvancedBus advancedBus;
        //private readonly IExchange exchange;
        //private readonly IQueue queue;

        //public TransactionBus(IAdvancedBus bus, string exchangeName, string queueName)
        //{
        //    advancedBus = bus;
        //    exchange = advancedBus.ExchangeDeclare(exchangeName.Length > 0 ? exchangeName : "DEFAULTED_NAME", ExchangeType.Fanout);
        //    queue = advancedBus.QueueDeclare(queueName);
        //}

        //public void Send<T>(T message) where T : class
        //{
        //    advancedBus.Bind(exchange, queue, "");

        //    advancedBus.Publish<T>(exchange, "", true, false, new Message<T>(message));
        //}

        //public void Consume<T>()
        //{
        //    var queue = advancedBus.QueueDeclare("my_queue");
        //    advancedBus.Consume(queue, (body, properties, info) => Task.Factory.StartNew(() =>
        //    {
        //        var message = Encoding.UTF8.GetString(body);
        //        //Console.WriteLine("Got message: '{0}'", message);
        //    }));
        //}


        private readonly IAdvancedBus advancedBus;

        public TransactionBus(IAdvancedBus bus)
        {
            advancedBus = bus;
        }

        public void Send<T>(T message, string exchangeName, string queueName) where T : class
        {
            var exchange = advancedBus.ExchangeDeclare(exchangeName.Length > 0 ? exchangeName : "DEFAULTED_NAME", ExchangeType.Fanout);
            var queue = advancedBus.QueueDeclare(queueName);
            advancedBus.Bind(exchange, queue, "");

            advancedBus.Publish<T>(exchange, "", true, false, new Message<T>(message));
        }
    }
}