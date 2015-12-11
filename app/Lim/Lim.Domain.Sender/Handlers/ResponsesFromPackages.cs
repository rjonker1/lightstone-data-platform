using System;
using System.Linq;
using System.Text;
using Common.Logging;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Extensions;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;
using Lim.Entities;

namespace Lim.Domain.Sender.Handlers
{
    public class ResponseFromPackageConsumer
    {
        private static readonly ILog Log = LogManager.GetLogger<ResponseFromPackageConsumer>();
        private readonly IRepository _repository;
        private readonly IPublishConfigurationMessages _publisher;

        public ResponseFromPackageConsumer(IRepository repository, IPublishConfigurationMessages publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public void Consume(IMessage<PackageResponseMessage> message)
        {
            Log.InfoFormat("Receiving response from package with Package Id {0} on Contract {1}", message.Body == null ? Guid.Empty : message.Body.PackageId, message.Body == null ? Guid.Empty : message.Body.ContractId);
            Log.Info(message.Body == null ? "Empty Message Body" : message.Body.Payload);

            if(message.Body == null)
                throw  new Exception("There is no package response available to save.");

            var package = new PackageResponses()
            {
                PackageId = message.Body.PackageId,
                Userid =  message.Body.UserId,
                ContractId = message.Body.ContractId,
                //AccountNumber = !string.IsNullOrEmpty(message.Body.AccountNumber) && HasDigit(message.Body.AccountNumber) ? Check(string.Join("", message.Body.AccountNumber.Where(Char.IsNumber)).TrimStart('0')) : -1,
                AccountNumber =  message.Body.AccountNumber.HasDigit() ? (string.Join("", message.Body.AccountNumber.Where(char.IsNumber)).TrimStart('0')).Check() : -1,
                ResponseDate = message.Body.ResponseDate,
                RequestId = message.Body.RequestId,
                Payload = !string.IsNullOrEmpty(message.Body.Payload) ? Encoding.UTF8.GetBytes(message.Body.Payload) : null,
                HasResponse = message.Body.HasData,
                Username = message.Body.Username ?? "unavailable"
            };
            _repository.Save(package);
           
            _publisher.SendToBus(new PackageConfigurationMessage(message.Body.PackageId, message.Body.UserId, message.Body.ContractId,
                package.AccountNumber, message.Body.RequestId));
        }
    }
}