using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Builder;
using Lace.Builder.Factory;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Functions.Json;
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
        private readonly IBuildSourceChain _buildSourceChain;

        public EntryPoint(IPublishMessages publisher)
        {
            _laceEvent = new PublishLaceEventMessages(publisher);
            _buildSourceChain = new CreateSourceChain();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                _laceEvent.PublishLaceReceivedRequestMessage(request.RequestAggregation.AggregateId,
                    LaceEventSource.EntryPoint);

                _buildSourceChain.Default(request.Package.Action);

                if (_buildSourceChain.SourceChain == null)
                {
                    Log.ErrorFormat("Source chain could not be built for action {0}", request.Package.Action.Name);
                    return EmptyResponse;
                }

                return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                    ? new Initialize(new LaceResponse(), request, _laceEvent, _buildSourceChain).LaceResponses ??
                      EmptyResponse
                    : EmptyResponse;
            }
            catch (Exception)
            {
                _laceEvent.PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(
                    request.RequestAggregation.AggregateId, LaceEventSource.EntryPoint);
                Log.ErrorFormat("Error occurred receiving request {0}",
                    JsonFunctions.JsonFunction.ObjectToJson(request));
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
