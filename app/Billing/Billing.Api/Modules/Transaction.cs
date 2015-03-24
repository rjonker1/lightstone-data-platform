using System;
using Billing.Api.Dtos;
using Common.Logging;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;
using Workflow;
using Workflow.Billing.Messages;

namespace Billing.Api.Modules
{
    public class Transaction : NancyModule
    {
        private readonly ILog _log;

        public Transaction(IPublishMessages publisher)
            : base("/transaction")
        {
            _log = LogManager.GetLogger(GetType());

            Get["/"] = _ => string.Format("Transaction API.");

            Post["/"] = o =>
            {
                _log.InfoFormat("Received post to create billing transaction");

                var transaction = this.Bind<CreateTransaction>();

                var message = new BillTransactionMessage(transaction.PackageIdentifier,
                    transaction.Context.User,
                    transaction.Context.Request,
                    transaction.Context.TransactionDate,
                    transaction.Context.TransactionId, transaction.Context.State);

                try
                {
                    publisher.Publish(message);
                    _log.DebugFormat("Message published to create billing transaction for transaction {0}", message.TransactionId);
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Failed to create a billing transaction for transaction {0}", transaction.Context.TransactionId);
                    _log.ErrorFormat("The reason was: {0}", e.Message);

                    return CannedResponses.Failure;
                }

                return CannedResponses.OK;
            };
        }
    }
}