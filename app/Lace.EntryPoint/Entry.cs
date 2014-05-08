using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response.ExternalServices;

namespace Lace.EntryPoint
{
    public class Entry : IEntryPoint
    {
        public IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                return new Initialize(request).LaceResponses;
            }
            catch (Exception)
            {
                return new List<LaceExternalServiceResponse>();
            }
        }
    }
}
