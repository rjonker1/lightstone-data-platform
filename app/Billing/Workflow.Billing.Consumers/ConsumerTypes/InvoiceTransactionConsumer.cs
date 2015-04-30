using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class InvoiceTransactionConsumer
    {

        private readonly IRepository<Transaction> _transactions;
        private readonly IRepository<Customer> _customerAccounts;
        private readonly IRepository<Client> _clientAccounts;
        private readonly IRepository<UserMeta> _users;
        private readonly IRepository<PackageMeta> _pacakges;
        private readonly IRepository<PreBilling> _preBillingRepository;
        private readonly IRepository<DataProviderTransaction> _dataProviderTransactions;

        public InvoiceTransactionConsumer(IRepository<Transaction> transactions, IRepository<UserMeta> users, IRepository<PreBilling> preBillingRepository, 
                                            IRepository<DataProviderTransaction> dataProviderTransactions, IRepository<Customer> customerAccounts, 
                                            IRepository<Client> clientAccounts, IRepository<PackageMeta> pacakges)
        {
            _transactions = transactions;
            _users = users;
            _preBillingRepository = preBillingRepository;
            _dataProviderTransactions = dataProviderTransactions;
            _customerAccounts = customerAccounts;
            _clientAccounts = clientAccounts;
            _pacakges = pacakges;
        }

        public void Consume(IMessage<InvoiceTransactionCreated> message)
        {

            //var customerId = new Guid("03641AC6-1561-4F1A-8AE5-7EB391541ABB");
            var transactionId = message.Body.TransactionId;
            var currentTransaction = _transactions.Where(x => x.Id == transactionId);

            if (!_transactions.Any(x => x.Id == transactionId)) return;

            foreach (var transaction in currentTransaction)
            {
                var customer = new Customer();
                var client = new Client();

                foreach (var account in _customerAccounts.Where(account => account.AccountNumber == transaction.AccountNumber))
                    customer = account;

                foreach (var account in _clientAccounts.Where(account => account.AccountNumber == transaction.AccountNumber))
                    client = account;

                var products = _dataProviderTransactions.Where(x => x.RequestId == transaction.RequestId);
                var user = Mapper.Map<UserMeta, User>(_users.Get(transaction.UserId));
                var package = Mapper.Map<PackageMeta, Package>(_pacakges.Get(transaction.PackageId));

                //Billing transaction recorded per product invoked
                foreach (var product in products)
                {
                    var preBillingTransaction = new PreBilling
                    {
                        //General
                        Id = Guid.NewGuid(),
                        BillingId = 101,
                        //Customer implementation
                        CustomerId = customer.CustomerId,
                        CustomerName = customer.CustomerName,
                        //Client implementation
                        ClientId = client.ClientId,
                        ClientName = client.ClientName,
                        //Shared
                        AccountNumber = transaction.AccountNumber,
                        UserId = transaction.UserId,
                        Username = user.Username,
                        TransactionId = transaction.Id,
                        PackageId = package.PackageId,
                        PackageName = package.PackageName,
                        RequestId = transaction.RequestId,
                        DataProviderId = product.Id,
                        DataProviderName = product.DataProviderName,
                        CostPrice = product.CostPrice,
                        RecommendedPrice = product.RecommendedPrice
                    };

                    _preBillingRepository.Save(preBillingTransaction);
                }

                return;
            }

        } 
    }
}