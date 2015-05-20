using System;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Lim.Domain.Messaging.Publishing
{
    public interface IPublishIntegrationMessages
    {
        void SendToBus<T>(T message) where T : class;
    }

    public class IntegrationMessagePublisher : IPublishIntegrationMessages
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly ILog _log;

        private const string Exchange = "DataPlatform.Integration.Receiver";
        private const string QueueName = "DataPlatform.Integration.Receiver";

        public IntegrationMessagePublisher(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(Exchange,
                ExchangeType.Fanout);
            var queue = _bus.QueueDeclare(QueueName);
            _bus.Bind(_exchange, queue, "");
            _log = LogManager.GetLogger(GetType());
        }

        public void SendToBus<T>(T message) where T : class
        {
            try
            {
                _bus.Publish<T>(_exchange, "", true, false, new Message<T>(message));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error sending message to Integration Bus beceause of {0}", ex, ex.Message);
            }
        }
    }
}
