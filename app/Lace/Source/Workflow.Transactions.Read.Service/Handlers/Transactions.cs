using System;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using NServiceBus;
using Shared.Messaging.Billing.Helpers;
using Workflow.Billing.Messages;
using Workflow.Billing.Messages.Publishable;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Transaction : IHandleMessages<BillTransactionMessage>
    {
        private readonly ITransactionRepository _transaction;
        private readonly IAdvancedBus _bus;

        public Transaction()
        {

        }

        public Transaction(ITransactionRepository transaction, IAdvancedBus bus)
        {
            _transaction = transaction;
            _bus = bus;
        }

        public void Handle(BillTransactionMessage message)
        {
            var transaction = new InvoiceTransaction(Guid.NewGuid(), message.TransactionDate,
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier, message.State,
                message.Contract, message.Account);

            _transaction.Add(transaction);

            new TransactionBus(_bus).Send(new InvoiceTransactionCreated(transaction.Id),
                "DataPlatform.Transactions.Billing", "DataPlatform.Transactions.Billing");
        }

    }
}