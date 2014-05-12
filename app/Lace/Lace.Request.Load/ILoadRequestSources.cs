using System;
using System.Collections.Generic;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Request.Load
{
    public interface ILoadRequestSources
    {
        List<LaceExternalServiceResponse> LaceResponses { get; }
        void BuildRequest(IDictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers);
        void HandleRequest(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers);
    }
}
