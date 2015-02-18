using System;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using Common.Logging;
using DataPlatform.Shared.Identifiers;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Api.Domain.Infrastructure.Transactions
{
    public interface ICreateBillingTransaction
    {
        bool BillingTransactionCreated { get; }
        void CreateBillingTransactionForPackage(Package package, Guid userId);
    }

    public class CreateBillingTransaction : ICreateBillingTransaction
    {
        private readonly ILog _log;
        private readonly IConnectToBilling _billing;
        public bool BillingTransactionCreated { get; private set; }

        public CreateBillingTransaction(IConnectToBilling billing)
        {
            _log = LogManager.GetLogger(GetType());
            _billing = billing;
        }

        public void CreateBillingTransactionForPackage(Package package, Guid userId)
        {
            try
            {
                var packageIdentifier = new PackageIdentifier(package.Id, new VersionIdentifier(package.Version));
                var requestIdentifier = new RequestIdentifier(Guid.NewGuid(), SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(userId);
                var transactionContext = new TransactionContext(Guid.NewGuid(), userIdentifier, requestIdentifier);
                var createTransaction = new CreateTransaction(packageIdentifier, transactionContext);

                _billing.CreateTransaction(createTransaction);

                BillingTransactionCreated = true;
            }
            catch (Exception)
            {
                _log.ErrorFormat("An error creating a billing transaction for package id {0} and user Id {1}",
                    package.Id, userId);
                BillingTransactionCreated = false;
            }
        }
    }
}
