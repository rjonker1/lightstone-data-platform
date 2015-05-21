using Common.Logging;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Models;
using Lim.Domain.Repository;

namespace Lim.Domain.Sender.Consumers
{
    public class ResponseFromPackageConsumer
    {
        private readonly ILog _log;
        private readonly ILimRepository _repository;

        public ResponseFromPackageConsumer(ILimRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Consume(IMessage<PackageResponseMessage> message)
        {
            _log.InfoFormat("Receiving response from package with Package Id {0) on Contract {1}", message.Body.PackageId, message.Body.ContractId);
            _log.Info(message.Body.Payload);

            new PackageResponse(message.Body.PackageId, message.Body.UserId, message.Body.ContractId, message.Body.AccountNumber,
                message.Body.ResponseDate, message.Body.Payload, message.Body.HasData).Insert(_repository);


        }
    }
}
