using System;
using System.Threading.Tasks;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Lim.Core;

namespace Lim.Domain.Messaging
{
    public class SendCommand : ISendCommand
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private static readonly ILog Log = LogManager.GetLogger<SendCommand>();

        private const string Exchange = "DataPlatform.Integration.Sender";
        private const string QueueName = "DataPlatform.Integration.Sender";

        public SendCommand(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(Exchange,ExchangeType.Fanout);
            var queue = _bus.QueueDeclare(QueueName);
            _bus.Bind(_exchange, queue, "");
        }

        public void Send<T>(T message) where T : Command
        {
            try
            {
                Task.Run(() => SendAsync(message));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error sending Integration Message because of {0}", ex, ex.Message);
            }
        }

        private void SendAsync<T>(T message) where T : Command
        {
            try
            {
                _bus.Publish(_exchange, "", true, false, new Message<T>(message));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error sending Integration Message because of {0}", ex, ex.Message);
            }
        }
    }
}
