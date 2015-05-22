﻿using Common.Logging;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;
using Lim.Domain.Models;
using Lim.Domain.Repository;

namespace Lim.Domain.Sender.Handlers
{
    public class ResponseFromPackageConsumer
    {
        private readonly ILog _log;
        private readonly ILimRepository _repository;
        private readonly IPublishConfigurationMessages _publisher;

        public ResponseFromPackageConsumer(ILimRepository repository, IPublishConfigurationMessages publisher)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Consume(IMessage<PackageResponseMessage> message)
        {
            _log.InfoFormat("Receiving response from package with Package Id {0} on Contract {1}", message.Body.PackageId, message.Body.ContractId);
            _log.Info(message.Body.Payload);

            new PackageResponse(message.Body.PackageId, message.Body.UserId, message.Body.ContractId, message.Body.AccountNumber,
                message.Body.ResponseDate, message.Body.Payload, message.Body.HasData, message.Body.RequestId, message.Body.Username).Insert(_repository);

            _publisher.SendToBus(new PackageConfigurationMessage(message.Body.PackageId, message.Body.UserId, message.Body.ContractId,
                message.Body.AccountNumber, message.Body.RequestId));
        }
    }
}