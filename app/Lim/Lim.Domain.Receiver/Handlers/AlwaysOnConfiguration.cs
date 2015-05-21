using Common.Logging;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Repository;

namespace Lim.Domain.Receiver.Handlers
{
    public class AlwaysOnConfigurationConsumer
    {
        private readonly ILog _log;
        private readonly ILimRepository _repository;

        public AlwaysOnConfigurationConsumer(ILimRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Consume(IMessage<PackageConfigurationMessage> message)
        {
            _log.InfoFormat("Receiving message with package with Package Id {0} on Contract {1}", message.Body.PackageId, message.Body.ContractId);
            
            _log.InfoFormat("Checking for Always on configurations requiring these packges");
        }
    }
}
