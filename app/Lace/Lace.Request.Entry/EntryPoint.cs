using System;
using System.Collections.Generic;
using Common.Logging;
using EasyNetQ;
using Lace.Events;
using Lace.Events.Messages;
using Lace.Functions.Json;
using Lace.Request.Entry.Checks;
using Lace.Request.Entry.RequestTypes;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Request.Entry
{
    public class EntryPoint : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly IGetRequiredRequestedTypes _getRequestedType;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceEvent _laceEvent;

        public EntryPoint(IBus bus)
        {
            _laceEvent = new PublishEvent(bus);
            _getRequestedType = new GetRequestedTypeToLoad();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                GetRequestedTypeToLoad(request);

                return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                    ? new Initialize(request, _getRequestedType.RequestedTypeToLoad,_laceEvent).LaceResponses ?? EmptyResponse
                    : EmptyResponse;
            }
            catch (Exception)
            {
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
