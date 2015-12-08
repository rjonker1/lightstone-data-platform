using System;
using Common.Logging;
using EasyNetQ;
using Lim.Domain.Base;
using Toolbox.LIVE.Domain;
using Toolbox.LIVE.Shared.Commands;

namespace Toolbox.LIVE.Infrastructure.Consumers.Write
{
    public class SendExecutedPackageConsumer
    {
        private static readonly ILog Log = LogManager.GetLogger<SendExecutedPackageConsumer>();
        private readonly IAggregateRepository<ExecutedPackageIntegration> _repository;

        public SendExecutedPackageConsumer(IAggregateRepository<ExecutedPackageIntegration> repository)
        {
            _repository = repository;
        }

        public void Consume(IMessage<SendExecutedPackage> message)
        {
            Log.InfoFormat("Receiving response from package with Package Id {0} on Contract {1}", message.Body == null ? Guid.Empty : message.Body.PackageId, message.Body == null ? Guid.Empty : message.Body.ContractId);

            var package = new ExecutedPackageIntegration(message.Body);
            _repository.Save(package, -1);
        }
    }
}