﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using NHibernate.Linq;
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

                var products = new List<DataProviderTransactionDto>();
                var prods = _dataProviderTransactions.Where(x => x.RequestId == transaction.RequestId &&
                                            ((x.StateId == (Int32) DataProviderResponseState.Successful) ||
                                                (x.StateId == (Int32) DataProviderResponseState.Partial) ||
                                                (x.StateId == (Int32) DataProviderResponseState.NoRecords)) &&
                                            //(x.Action == customer.BillingType || x.Action == client.BillingType))
                                            x.Action == "Response")
                                            .Select(x => new DataProviderTransactionDto
                                            {
                                                Id = x.StreamId,
                                                DataProviderName = x.DataProviderName,
                                                CostPrice = x.CostPrice,
                                                RecommendedPrice = x.RecommendedPrice,
                                                ResponseState = (DataProviderResponseState) Enum.Parse(typeof(DataProviderResponseState), x.State),
                                                TransactionState = (DataProviderResponseState) Enum.Parse(typeof(DataProviderResponseState), transaction.State)
                                            });

                foreach (var dataProviderTransaction in prods)
                {
                    var checkDup = products.Where(x => x.DataProviderName == dataProviderTransaction.DataProviderName);
                    if (checkDup.Any()) continue;

                    products.Add(dataProviderTransaction);
                }

                var user = Mapper.Map<UserMeta, User>(_users.Get(transaction.UserId));
                var package = Mapper.Map<PackageMeta, Package>(_pacakges.Get(transaction.PackageId));

                //Billing transaction recorded per product invoked
                foreach (var product in products)
                {
                    try
                    {
                        var preBillingTransaction = new PreBilling
                        {
                            //General
                            Id = Guid.NewGuid(),
                            Created = transaction.Date,
                            CreatedBy = user.Username,
                            BillingId = 101,
                            //Customer implementation
                            CustomerId = customer.CustomerId,
                            CustomerName = customer.CustomerName,
                            //Client implementation
                            ClientId = client.ClientId,
                            ClientName = client.ClientName,
                            //Shared
                            AccountNumber = transaction.AccountNumber,
                            ContractId = transaction.ContractId,
                            BillingType = (client.ClientId == new Guid()) ? customer.BillingType : client.BillingType,
                            User = new User
                            {
                                UserId = transaction.UserId,
                                Username = user.Username
                            },
                            UserTransaction = new UserTransaction
                            {
                                TransactionId = transaction.Id,
                                RequestId = transaction.RequestId
                            },
                            Package = new Package
                            {
                                PackageId = package.PackageId,
                                PackageName = package.PackageName,
                                PackageCostPrice = transaction.PackageCostPrice,
                                PackageRecommendedPrice = transaction.PackageRecommendedPrice,
                            },
                            DataProvider = new DataProvider
                            {
                                DataProviderId = product.Id,
                                DataProviderName = product.DataProviderName,
                                CostPrice = product.CostPrice,
                                RecommendedPrice = product.RecommendedPrice,
                                ResponseState = product.ResponseState,
                                TransactionState = product.TransactionState
                            }
                        };

                        _preBillingRepository.Save(preBillingTransaction, true);
                    }
                    catch (Exception e)
                    {
                        this.Error(() => "Potential Mapping error of meta data for transaction. See below for details.");
                        this.Error(() => e);
                    }
                }

                return;
            }

        }
    }
}