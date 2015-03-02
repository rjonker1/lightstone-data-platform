using System;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using Common.Logging;
using DataPlatform.Shared.Identifiers;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Api.Domain.Infrastructure.Billing
{
    public interface ICreateBillingTransaction
    {
        bool BillingCreated { get; }
        void CreateBillingTransactionForPackage(Package package, Guid userId, Guid requestId);
    }

    public class CreateBillingTransaction : ICreateBillingTransaction
    {
        private readonly ILog _log;
        private readonly IConnectToBilling _billing;
        public bool BillingCreated { get; private set; }

        public CreateBillingTransaction(IConnectToBilling billing)
        {
            _log = LogManager.GetLogger(GetType());
            _billing = billing;
        }

        public void CreateBillingTransactionForPackage(Package package, Guid userId, Guid requestId)
        {
            try
            {
                var packageIdentifier = new PackageIdentifier(package.Id, new VersionIdentifier(package.Version));
                var requestIdentifier = new RequestIdentifier(requestId, SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(userId);
                var transactionContext = new TransactionContext(Guid.NewGuid(), userIdentifier, requestIdentifier);
                var createTransaction = new CreateTransaction(packageIdentifier, transactionContext);

                _billing.CreateTransaction(createTransaction);

                BillingCreated = true;
            }
            catch (Exception)
            {
                _log.ErrorFormat("An error creating a billing transaction for package id {0} and user Id {1}",
                    package.Id, userId);
                BillingCreated = false;
            }
        }
    }
}
