using System;
using System.Collections.Generic;
using Common.Logging;
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

        public EntryPoint()
        {
            _getRequestedType = new GetRequestedTypeToLoad();
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                GetRequestedTypeToLoad(request);

                return !_checkForDuplicateRequests.IsRequestDuplicated(request)
                    ? new Initialize(request, _getRequestedType.RequestedTypeToLoad).LaceResponses ?? EmptyResponse
                    : EmptyResponse;
            }
            catch (Exception)
            {
                Log.ErrorFormat("Error occurred receiving request {0}",
                    Shared.Helpers.JsonFunctions.ObjectToJson(request));
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
