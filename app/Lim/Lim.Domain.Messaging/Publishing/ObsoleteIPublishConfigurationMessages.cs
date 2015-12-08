using System;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Lim.Domain.Messaging.Publishing
{
   [Obsolete("Use IPublish")]
    public interface IPublishConfigurationMessages
    {
        void SendToBus<T>(T message) where T : class;
    }

    [Obsolete("Use PublishMessage")]
    public class ConfigurationMessagePublisher : IPublishConfigurationMessages
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly ILog _log;

        private const string Exchange = "DataPlatform.Integration.Receiver";
        private const string QueueName = "DataPlatform.Integration.Receiver";

        public ConfigurationMessagePublisher(IAdvancedBus bus)
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
                _log.ErrorFormat("Error sending Configuration Message because of {0}", ex, ex.Message);
            }
        }
    }
}
