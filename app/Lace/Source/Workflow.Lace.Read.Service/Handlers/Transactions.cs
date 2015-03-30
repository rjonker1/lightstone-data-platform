using System;
using NServiceBus;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Transaction : IHandleMessages<BillTransactionMessage>
    {
        private readonly IRepository _repository;

        public Transaction()
        {

        }

        public Transaction(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(BillTransactionMessage message)
        {
            var transaction = new InvoiceTransaction(Guid.NewGuid(), message.TransactionDate,
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier, message.State);

            _repository.Add(transaction);
        }
    }
}