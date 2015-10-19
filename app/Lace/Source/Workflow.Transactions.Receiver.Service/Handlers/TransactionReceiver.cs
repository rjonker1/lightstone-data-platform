using System;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Messages;
using Workflow.Billing.Messages.Publishable;
using Workflow.Lace.Messages.Core;

namespace Workflow.Transactions.Receiver.Service.Handlers
{
    public class TransactionReceiver
    {
        private readonly ITransactionRepository _transaction;
        private readonly IPublishBillingMessages _publisher;

        public TransactionReceiver(ITransactionRepository transaction, IPublishBillingMessages publisher)
        {
            _transaction = transaction;
            _publisher = publisher;
        }

        public void Consume(IMessage<BillTransactionMessage> message)
        {
            var transaction = new InvoiceTransaction(Guid.NewGuid(), message.Body.TransactionDate,
                message.Body.PackageIdentifier, message.Body.RequestIdentifier, message.Body.UserIdentifier,
                message.Body.State,
                message.Body.Contract, message.Body.Account);

            _transaction.Add(transaction);

            _publisher.SendToBus(new InvoiceTransactionCreated(transaction.Id));

            new TransactionRequest(Guid.NewGuid(), message.Body.RequestIdentifier, message.Body.UserIdentifier, message.Body.State, DateTime.UtcNow)
                .Audit(_transaction);
        }
    }
}