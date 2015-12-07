using System;
using System.Linq;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Builders;
using Xunit;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing
{
    public class when_replaying_transactions_to_billingTransaction : BaseTestHelper
    {
        private IRepository<global::Workflow.Billing.Domain.Entities.Transaction> _transactionRepository;

        private IRepository<PackageMeta> _packageRepository;
        private IRepository<ContractMeta> _contractRepository;
        private IRepository<AccountMeta> _accountRepository;
        private IRepository<UserMeta> _userRepository;

        private readonly IAdvancedBus _bus;

        private PackageMeta _packageMeta;
        private ContractMeta _contractMeta;
        private AccountMeta _accountMeta;
        private UserMeta _userMeta;
        private global::Workflow.Billing.Domain.Entities.Transaction _transaction;

        public when_replaying_transactions_to_billingTransaction()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue"); ;
        }

        public override void Observe()
        {
            _transactionRepository = Container.Resolve<IRepository<global::Workflow.Billing.Domain.Entities.Transaction>>();
            _packageRepository = Container.Resolve<IRepository<PackageMeta>>();
            _contractRepository = Container.Resolve<IRepository<ContractMeta>>();
            _accountRepository = Container.Resolve<IRepository<AccountMeta>>();
            _userRepository = Container.Resolve<IRepository<UserMeta>>();

            _packageMeta = new PackageMeta
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                PackageId = Guid.NewGuid(),
                PackageName = "TestPackage"
            };

            _contractMeta = new ContractMeta
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                ContractBundleId = Guid.NewGuid(),
                ContractBundleName = "TestBundle",
                ContractBundlePrice = 0.00,
                ContractBundleTransactionLimit = 0
            };

            _accountMeta = new AccountMeta
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                AccountNumber = "TESS00000",
                BillingType = "INTERNAL"
            };

            _userMeta = new UserMeta
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                FirstName = "Test",
                LastName = "Eroonie",
                Username = "testeroonie@123.com"
            };

            _transaction = new global::Workflow.Billing.Domain.Entities.Transaction(DateTime.UtcNow, _packageMeta.PackageId, 1, 0.00, 0.00, _contractMeta.ContractId, 1, 
                                                                                _userMeta.Id, Guid.NewGuid(), "TST", "TSTSERV", "Successful", 1, _accountMeta.AccountNumber);
            _transaction.Id = Guid.NewGuid();
        }

        [Observation]
        public void should_have_package_meta()
        {
            var preSave = _packageRepository.Count();
            _packageRepository.SaveOrUpdate(_packageMeta);
            var postSave = _packageRepository.Count();

            Assert.Equal(postSave, preSave + 1);
        }

        [Observation]
        public void should_have_contract_meta()
        {
            var preSave = _contractRepository.Count();
            _contractRepository.SaveOrUpdate(_contractMeta);
            var postSave = _contractRepository.Count();

            Assert.Equal(postSave, preSave + 1);
        }

        [Observation]
        public void should_have_account_meta()
        {
            var preSave = _accountRepository.Count();
            _accountRepository.SaveOrUpdate(_accountMeta);
            var postSave = _accountRepository.Count();

            Assert.Equal(postSave, preSave + 1);
        }

        [Observation]
        public void should_have_user_meta()
        {
            var preSave = _userRepository.Count();
            _userRepository.SaveOrUpdate(_userMeta);
            var postSave = _userRepository.Count();

            Assert.Equal(postSave, preSave + 1);
        }

        [Observation]
        public void should_have_transaction()
        {
            var preSave = _transactionRepository.Count();
            _transactionRepository.SaveOrUpdate(_transaction);
            var postSave = _transactionRepository.Count();

            Assert.Equal(postSave, preSave + 1);
        }

        [Observation]
        public void should_re_process_invoice_transaction_created()
        {
            var bus = new TransactionBus(_bus);

            foreach (var transaction in _transactionRepository)
            {
                var message = new InvoiceTransactionCreated(transaction.Id);
                bus.SendDynamic(message);
            }

           bus.ShouldNotBeNull();
        }
    }
}