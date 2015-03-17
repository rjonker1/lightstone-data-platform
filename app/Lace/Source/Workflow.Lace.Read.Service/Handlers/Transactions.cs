using System;
using NServiceBus;
using Workflow.Billing.Domain;
using Workflow.Billing.Repository;
using Workflow.Lace.Messages.Events;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Transaction : IHandleMessages<TransactionCreated>
    {
        private readonly IRepository _repository;

        public Transaction()
        {

        }

        public Transaction(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(TransactionCreated message)
        {
            var transaction = new InvoiceTransaction(Guid.NewGuid(), message.TransactionDate,
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier, message.State);

            _repository.Add(transaction);
        }
    }
}
