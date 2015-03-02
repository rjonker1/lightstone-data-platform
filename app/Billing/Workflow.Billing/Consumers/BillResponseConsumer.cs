using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers
{
    public class BillResponseConsumer : IConsume<BillResponseMessage>
    {
        private static readonly ILog _log = LogManager.GetLogger<BillTransactionConsumer>();
        private readonly IRepository _repository;

        public BillResponseConsumer(IRepository repository)
        {
            this._repository = repository;
        }

        public void Consume(BillResponseMessage message)
        {
            if (!ShouldCreateTransaction(message))
            {
                _log.WarnFormat("Not creating a new response for message with request Id {0}", message.RequestId);
                return;
            }

            var request = new InvoiceResponse(message.RequestId, message.TransactionDate, 
                message.PackageIdentifier, message.RequestIdentifier, message.UserIdentifier);

            _repository.Add(request);

            _log.InfoFormat("Response {0} was created", message.RequestId);
        }

        private bool ShouldCreateTransaction(BillResponseMessage message)
        {
            var match = _repository.Get<InvoiceResponse>(message.RequestId);

            return match == null;
        }
    }
}