using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Request.Entry
{
    public class EntryPoint : IEntryPoint
    {
        private readonly ILoadRequestSources _loadRequestSources;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public EntryPoint(ILoadRequestSources loadRequestSources)
        {
            _loadRequestSources = loadRequestSources;
        }
        
        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                return new Initialize(request,_loadRequestSources).LaceResponses ?? EmptyResponse;
            }
            catch (Exception)
            {
                Log.ErrorFormat("Error occured receiving request {0}", Shared.Helpers.JsonFunctions.ObjectToJson(request));
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
