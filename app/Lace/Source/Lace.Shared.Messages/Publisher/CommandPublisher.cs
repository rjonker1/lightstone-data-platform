using System;
using Common.Logging;
using Lace.Shared.Monitoring.Messages.Core;
using NServiceBus;

namespace Lace.Shared.Monitoring.Messages.Publisher
{
    public class CommandPublisher : IPublishCommandMessages
    {
        private readonly IBus _bus;
        private readonly ILog _log;

        public CommandPublisher(IBus bus)
        {
            _bus = bus;
            _log = LogManager.GetLogger(GetType());
        }

        public void SendToBus<T>(T message) where T : class
        {
            try
            {
                _bus.Send(message);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error sending message to Data Provider Message Bus: {0}", ex.Message);
            }
        }
    }
}
