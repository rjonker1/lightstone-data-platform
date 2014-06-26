using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Builder;
using Lace.Builder.Factory;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Extensions;
using Lace.Request.Entry.Checks;
using Lace.Response;
using Lace.Response.ExternalServices;
using Monitoring.Sources.Lace;
using Workflow;

namespace Lace.Request.Entry
{
    public class EntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceEvent _laceEvent;
        private IBuildSourceChain _sourceChain;
        private IBootstrap _bootstrap;

        public EntryPoint(IPublishMessages publisher)
        {
            _laceEvent = new PublishLaceEventMessages(publisher);
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                _laceEvent.PublishLaceReceivedRequestMessage(request.RequestAggregation.AggregateId,
                    LaceEventSource.EntryPoint);


                _sourceChain = new CreateSourceChain(request.Package.Action);
                _sourceChain.Build();

                if (_sourceChain.SourceChain == null)
                {
                    Log.ErrorFormat("Source chain could not be built for action {0}", request.Package.Action.Name);
                    return EmptyResponse;
                }

                if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return EmptyResponse;

                _bootstrap = new Initialize(new LaceResponse(), request, _laceEvent, _sourceChain);
                _bootstrap.Execute();

                return _bootstrap.LaceResponses ?? EmptyResponse;

            }
            catch (Exception)
            {
                _laceEvent.PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(
                    request.RequestAggregation.AggregateId, LaceEventSource.EntryPoint);
                Log.ErrorFormat("Error occurred receiving request {0}",
                    request.ObjectToJson());
                return EmptyResponse;
            }
        }

        private static IList<LaceExternalServiceResponse> EmptyResponse
        {
            get
            {
                return new List<LaceExternalServiceResponse>()
                {
                    new LaceExternalServiceResponse()
                    {
                        Response = new LaceResponse()
                        {

                        }
                    }
                };
            }
        }
    }
}
