﻿using System;
using System.Configuration;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using NServiceBus;
using Shared.Messaging.Billing.Helpers;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;
using Workflow.BuildingBlocks;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Transaction : IHandleMessages<BillTransactionMessage>
    {
        private readonly IRepository _repository;
        private readonly IAdvancedBus _bus;

        public Transaction()
        {

        }

        public Transaction(IRepository repository)
        {
            _repository = repository;
            _bus =
                BusFactory.CreateAdvancedBus(
                    ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString);
        }

        public void Handle(BillTransactionMessage message)
        {
            var transaction = new InvoiceTransaction(Guid.NewGuid(), message.TransactionDate,
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier, message.State,
                message.Contract, message.Account);

            _repository.Add(transaction);

            new TransactionBus(_bus).Send(new InvoiceTransactionCreated(transaction.Id),
                "DataPlatform.Transactions.Billing", "DataPlatform.Transactions.Billing");
        }

    }
}