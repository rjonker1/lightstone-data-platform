using Common.Logging;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;

namespace Lim.Domain.Receiver.Consumers
{
    public class PackageResponseReceiver
    {
        private readonly ILog _log;

        public PackageResponseReceiver()
        {
            _log = LogManager.GetLogger(GetType());
        }
        public void Consume(IMessage<MappedPackageResponseSentMessage> message)
        {
            _log.InfoFormat("Receiving response from package with Package Id {0) on Contract {1}", message.Body.PacakgeId,message.Body.PacakgeId);
            _log.Info(message.Body.Payload);
        }
    }
}
