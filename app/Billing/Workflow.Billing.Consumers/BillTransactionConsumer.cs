using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers
{
    public class BillTransactionConsumer : IConsume<BillTransactionMessage>
    {
        private static readonly ILog _log = LogManager.GetLogger<BillTransactionConsumer>();
        private readonly IRepository _repository;

        public BillTransactionConsumer(IRepository repository)
        {
            this._repository = repository;
        }

        public void Consume(BillTransactionMessage message)
        {
            if (!ShouldCreateTransaction(message))
            {
                _log.WarnFormat("Not creating a new transaction for message with transaction Id {0}", message.TransactionId);
                return;
            }

            var transaction = new InvoiceTransaction(message.TransactionId, message.TransactionDate, 
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier);

            _repository.Add(transaction);

            _log.InfoFormat("Transaction {0} was created", message.TransactionId);
        }

        private bool ShouldCreateTransaction(BillTransactionMessage message)
        {
            var match = _repository.Get<InvoiceTransaction>(message.TransactionId);

            return match == null;
        }
    }
}