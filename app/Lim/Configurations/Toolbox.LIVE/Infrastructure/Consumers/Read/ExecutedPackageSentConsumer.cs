using System.Text;
using Common.Logging;
using EasyNetQ;
using Lim.Core;
using Lim.Domain.Events;
using Lim.Entities;
using Toolbox.LIVE.Domain.Events;

namespace Toolbox.LIVE.Infrastructure.Consumers.Read
{
    public class ExecutedPackageSentConsumer
    {
        private static readonly ILog Log = LogManager.GetLogger<ExecutedPackageSentConsumer>();
        private readonly IRepository _repository;
        private readonly IPublish _publisher;

        public ExecutedPackageSentConsumer(IRepository repository, IPublish publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public void Consume(IMessage<ExecutedPackageSent> message)
        {
            var package = new PackageResponses
            {
                PackageId = message.Body.PackageId,
                Userid = message.Body.UserId,
                ContractId = message.Body.ContractId,
                AccountNumber = message.Body.AccountNumber,
                ResponseDate = message.Body.ResponseDate,
                RequestId = message.Body.RequestId,
                Payload = !string.IsNullOrEmpty(message.Body.Payload) ? Encoding.UTF8.GetBytes(message.Body.Payload) : null,
                HasResponse = message.Body.HasData,
                Username = message.Body.Username
            };

            _repository.Save(package);

            _publisher.Publish(new PackageReceived(package.PackageId, package.Userid, package.ContractId, package.AccountNumber, package.RequestId));
        }
    }
}