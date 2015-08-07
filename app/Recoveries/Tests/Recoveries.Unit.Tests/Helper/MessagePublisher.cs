using EasyNetQ;
using EasyNetQ.Topology;

namespace Recoveries.Unit.Tests.Helper
{
    public sealed class MessagePublisher
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly IQueue _queue;

        private MessagePublisher(IAdvancedBus bus, string queueName, string exchangeName)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(exchangeName,
                ExchangeType.Fanout);
            _queue = _bus.QueueDeclare(queueName);
        }

        public static MessagePublisher Configure(IAdvancedBus bus, string queueName, string exchangeName)
        {
            return new MessagePublisher(bus, queueName, exchangeName);
        }

        public void SendToBus<T>(T message) where T : class
        {
            _bus.Publish<T>(_exchange, "", true, false, new Message<T>(message));
        }
    }
}
