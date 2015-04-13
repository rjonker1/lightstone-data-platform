using System;
using NServiceBus;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Transaction : IHandleMessages<BillTransactionMessage>
    {
        private readonly IRepository _repository;
        private readonly ISendOnlyBus _bus;

        public Transaction()
        {

        }

        public Transaction(IRepository repository, ISendOnlyBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public void Handle(BillTransactionMessage message)
        {
            var transactionId = Guid.NewGuid();
            var transaction = new InvoiceTransaction(Guid.NewGuid(), message.TransactionDate,
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier, message.State,
                message.Contract, message.Account);

            _repository.Add(transaction);

           // _bus.Send("DataPlatform.Transactions.Billing",new BillingTransactionCreated(transactionId));
        }

    }
}