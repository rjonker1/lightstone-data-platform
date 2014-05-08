using System;
using System.Collections.Generic;
using Lace.Response.ExternalServices;

namespace Lace.Request.Entry
{
    public class EntryPoint : IEntryPoint
    {
        private readonly ILoadRequestSources _loadRequestSources;

        public EntryPoint(ILoadRequestSources loadRequestSources)
        {
            _loadRequestSources = loadRequestSources;
        }
        
        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                return new Initialize(request,_loadRequestSources).LaceResponses;
            }
            catch (Exception)
            {
                return new List<LaceExternalServiceResponse>();
            }
        }
    }
}
