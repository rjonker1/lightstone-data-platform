using System.Collections.Generic;
using Lace.Request;
using Lace.Response.ExternalServices;

namespace Lace.EntryPoint
{
    public interface IEntryPoint
    {
        IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request);
    }
}
