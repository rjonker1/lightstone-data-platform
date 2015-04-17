using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class InvoiceTransactionConsumer
    {

        private readonly IRepository<Transaction> _transactions;
        private readonly IRepository<UserMeta> _users;
        private readonly IRepository<PreBilling> _preBillingRepository;
        private readonly IRepository<DataProviderTransaction> _dataProviderTransactions;

        public InvoiceTransactionConsumer(IRepository<Transaction> transactions, IRepository<UserMeta> users, IRepository<PreBilling> preBillingRepository, IRepository<DataProviderTransaction> dataProviderTransactions)
        {
            _transactions = transactions;
            _users = users;
            _preBillingRepository = preBillingRepository;
            _dataProviderTransactions = dataProviderTransactions;
        }

        public void Consume(IMessage<InvoiceTransactionCreated> message)
        {

            var customerId = new Guid("03641AC6-1561-4F1A-8AE5-7EB391541ABB");
            var transactionId = message.Body.TransactionId;
            var currentTransaction = _transactions.Where(x => x.Id == transactionId);

            if (!_transactions.Any(x => x.Id == transactionId)) return;

            foreach (var transaction in currentTransaction)
            {

                var products = _dataProviderTransactions.Where(x => x.RequestId == transaction.RequestId);
                var user = Mapper.Map<UserMeta, User>(_users.Get(new Guid("03641AC6-1561-4F1A-8AE5-7EB391541D3A")));

                //Billing transaction recorded per product invoked
                foreach (var product in products)
                {
                    var preBillingTransaction = new PreBilling
                    {
                        Id = Guid.NewGuid(),
                        BillingId = 101,
                        CustomerId = customerId,
                        CustomerName = "CustomerABC",
                        AccountNumber = transaction.AccountNumber,
                        UserId = transaction.UserId,
                        Username = user.Username,
                        TransactionId = transaction.Id,
                        PackageId = transaction.PackageId,
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