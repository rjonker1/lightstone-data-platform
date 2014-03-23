using System;
using Billing.Api.Dtos;
using Common.Logging;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;
using Workflow;
using Workflow.Billing.Messages;

namespace Billing.Api
{
    public class Transaction : NancyModule
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public Transaction(IPublishMessages publisher)
        {
            Post["/transaction"] = o =>
                                   {
                                       log.InfoFormat("Received post to create billing transaction");

                                       var transaction = this.Bind<CreateTransaction>();
                                       var message = new BillTransactionMessage(transaction.UserId,
                                           transaction.TransactionId);

                                       try
                                       {
                                           publisher.Publish(message);
                                           log.DebugFormat("Message published to create billing transaction for transaction {0}", message.TransactionId);
                                       }
                                       catch (Exception e)
                                       {
                                           log.ErrorFormat("Failed to create a billing transaction");
                                           log.ErrorFormat("The reason was: {0}", e.Message);
                                       }


                                       return CannedResponses.OK;
                                   };
        }
    }
}