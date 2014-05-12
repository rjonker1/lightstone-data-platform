using System.Collections.Generic;
using Lace.Response.ExternalServices;

namespace Lace.Request.Entry
{
    public interface IEntryPoint
    {
        IList<LaceExternalServiceResponse> GetResponsesFromLace(ILaceRequest request);
    }
}
