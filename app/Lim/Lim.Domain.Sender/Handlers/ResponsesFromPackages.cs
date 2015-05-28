using System;
using System.Linq;
using Common.Logging;
using EasyNetQ;
using Lim.Domain.Entities;
using Lim.Domain.Entities.EntityRepository;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;

namespace Lim.Domain.Sender.Handlers
{
    public class ResponseFromPackageConsumer
    {
        private readonly ILog _log;
        private readonly IAmEntityRepository _repository;
        private readonly IPublishConfigurationMessages _publisher;

        public ResponseFromPackageConsumer(IAmEntityRepository repository, IPublishConfigurationMessages publisher)
        {
            _repository = repository;
            _publisher = publisher;
            _log = LogManager.GetLogger(GetType());
        }

        public void Consume(IMessage<PackageResponseMessage> message)
        {
            _log.InfoFormat("Receiving response from package with Package Id {0} on Contract {1}", message.Body.PackageId, message.Body.ContractId);
            _log.Info(message.Body.Payload);

            var package = new PackageResponses()
            {
                PackageId = message.Body.PackageId,
                Userid =  message.Body.UserId,
                ContractId = message.Body.ContractId,
                AccountNumber = !string.IsNullOrEmpty(message.Body.AccountNumber) ? int.Parse(string.Join("", message.Body.AccountNumber.Where(Char.IsNumber)).TrimStart('0')) : -1,
                ResponseDate = message.Body.ResponseDate,
                RequestId = message.Body.RequestId,
                Payload = message.Body.Payload,
                HasResponse = message.Body.HasData,
                Username = message.Body.Username
            };
            _repository.Save(package);

            _publisher.SendToBus(new PackageConfigurationMessage(message.Body.PackageId, message.Body.UserId, message.Body.ContractId,
                message.Body.AccountNumber, message.Body.RequestId));
        }
    }
}