using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Functions.Json;
using Lace.Request.Entry.Checks;
using Lace.Request.Entry.RequestTypes;
using Lace.Response;
using Lace.Response.ExternalServices;
using Monitoring.Sources.Lace;
using Workflow;

namespace Lace.Request.Entry
{
    public class EntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IGetRequiredRequestedTypes _getRequestedType;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceEvent _laceEvent;

        public EntryPoint(IPublishMessages publisher)
        {
            _laceEvent = new PublishLaceEventMessages(publisher);
            _getRequestedType = new GetRequestedTypeToLoad();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                _laceEvent.PublishLaceReceivedRequestMessage(request.RequestAggregation.AggregateId, LaceEventSource.EntryPoint);

                GetRequestedTypeToLoad(request);

                return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                    ? new Initialize(request, _getRequestedType.RequestedTypeToLoad,_laceEvent).LaceResponses ?? EmptyResponse
                    : EmptyResponse;

                
            }
            catch (Exception)
            {
                _laceEvent.PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(request.RequestAggregation.AggregateId, LaceEventSource.EntryPoint);
                Log.ErrorFormat("Error occurred receiving request {0}",
                    JsonFunctions.JsonFunction.ObjectToJson(request));
                return EmptyResponse;
            }
        }

        private void GetRequestedTypeToLoad(ILaceRequest request)
        {
            _getRequestedType.GetRequestedType(request);
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
