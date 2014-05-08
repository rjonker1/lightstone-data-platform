using System;
using System.Collections.Generic;
using Lace.Response.ExternalServices;

namespace Lace.Request.Entry
{
    public class EntryPoint : IEntryPoint
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
