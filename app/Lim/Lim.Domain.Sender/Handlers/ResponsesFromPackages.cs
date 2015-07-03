using System;
using System.Linq;
using System.Text;
using Common.Logging;
using EasyNetQ;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;

namespace Lim.Domain.Sender.Handlers
{
    public class ResponseFromPackageConsumer
    {
        private readonly ILog _log;
        private readonly IAmRepository _repository;
        private readonly IPublishConfigurationMessages _publisher;

        public ResponseFromPackageConsumer(IAmRepository repository, IPublishConfigurationMessages publisher)
        {
            _repository = repository;
            _publisher = publisher;
            _log = LogManager.GetLogger(GetType());
        }

        public void Consume(IMessage<PackageResponseMessage> message)
        {
            _log.InfoFormat("Receiving response from package with Package Id {0} on Contract {1}", message.Body == null ? Guid.Empty : message.Body.PackageId, message.Body == null ? Guid.Empty : message.Body.ContractId);
            _log.Info(message.Body == null ? "Empty Message Body" : message.Body.Payload);

            if(message.Body == null)
                throw  new Exception("There is no package response available to save.");

            var package = new PackageResponses()
            {
                PackageId = message.Body.PackageId,
                Userid =  message.Body.UserId,
                ContractId = message.Body.ContractId,
                AccountNumber = !string.IsNullOrEmpty(message.Body.AccountNumber) && HasDigit(message.Body.AccountNumber) ? int.Parse(string.Join("", message.Body.AccountNumber.Where(Char.IsNumber)).TrimStart('0')) : -1,
                ResponseDate = message.Body.ResponseDate,
                RequestId = message.Body.RequestId,
                Payload = !string.IsNullOrEmpty(message.Body.Payload) ? Encoding.UTF8.GetBytes(message.Body.Payload) : null,
                HasResponse = message.Body.HasData,
                Username = message.Body.Username ?? "unavailable"
            };
            _repository.Save(package);
           
            _publisher.SendToBus(new PackageConfigurationMessage(message.Body.PackageId, message.Body.UserId, message.Body.ContractId,
                message.Body.AccountNumber, message.Body.RequestId));
        }

        private static bool HasDigit(string value)
        {
            return value.Any(Char.IsDigit);
        }
    }
}