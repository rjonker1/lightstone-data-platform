using System;
using System.Threading.Tasks;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Lim.Core;
using IMessage = Lim.Core.IMessage;

namespace Lim.Domain.Messaging
{
    public class PublishMessage : IPublish
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private static readonly ILog Log = LogManager.GetLogger<PublishMessage>();

        private const string Exchange = "DataPlatform.Integration.Receiver";
        private const string QueueName = "DataPlatform.Integration.Receiver";

        public PublishMessage(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(Exchange, ExchangeType.Fanout);
            var queue = _bus.QueueDeclare(QueueName);
            _bus.Bind(_exchange, queue, "");
        }

        public void Publish<T>(T @event) where T : IMessage
        {
            try
            {
                Task.Run(() => PublishAsync(@event));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error sending Integration Message because of {0}", ex, ex.Message);
            }
        }

        private void PublishAsync<T>(T @event) where T : IMessage
        {
            try
            {
                _bus.Publish<IMessage>(_exchange, "", true, false, new Message<IMessage>(@event));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error publishing Integration Message because of {0}", ex, ex.Message);
            }
        }
    }
}