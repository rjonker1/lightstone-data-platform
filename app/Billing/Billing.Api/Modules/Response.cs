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
    public class Response : NancyModule
    {
        private readonly ILog _log;

        public Response(IPublishMessages publisher)
            : base("/response")
        {
            _log = LogManager.GetLogger(GetType());

            Get["/"] = _ => string.Format("Response Billing API.");

            Post["/"] = o =>
            {
                _log.InfoFormat("Received post to create billing response");

                var transaction = this.Bind<CreateResponse>();

                var message = new BillResponseMessage(transaction.PackageIdentifier,
                    transaction.Context.User,
                    transaction.Context.Request,
                    transaction.Context.TransactionDate,
                    transaction.Context.TransactionId);
                try
                {
                    publisher.Publish(message);
                    _log.DebugFormat("Message published to create billing response for request {0}",
                        message.RequestId);
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Failed to create a billing response for request {0}",
                        transaction.Context.TransactionId);
                    _log.ErrorFormat("The reason was: {0}", e.Message);

                    return CannedResponses.Failure;
                }

                return CannedResponses.OK;
            };

        }
    }
}