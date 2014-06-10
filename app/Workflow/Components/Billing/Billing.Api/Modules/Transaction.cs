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
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public Transaction(IPublishMessages publisher)
            : base("/transaction")
        {
            Get["/"] = _ => string.Format("Transaction API.");

            Post["/"] = o =>
            {
                log.InfoFormat("Received post to create billing transaction");

                var transaction = this.Bind<CreateTransaction>();
                var message = new BillTransactionMessage(transaction.PackageIdentifier,
                    transaction.Context.User,
                    transaction.Context.Request,
                    transaction.Context.TransactionDate,
                    transaction.Context.TransactionId);

                try
                {
                    publisher.Publish(message);
                    log.DebugFormat("Message published to create billing transaction for transaction {0}", message.TransactionId);
                }
                catch (Exception e)
                {
                    log.ErrorFormat("Failed to create a billing transaction for transaction {0}", transaction.Context.TransactionId);
                    log.ErrorFormat("The reason was: {0}", e.Message);

                    return CannedResponses.Failure;
                }

                return CannedResponses.OK;
            };
        }
    }
}