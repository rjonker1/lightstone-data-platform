using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace
{
    public interface IHandle
    {
        List<LaceExternalServiceResponse> LaceResponses { get; }
        void HandleRequest(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers);
    }
}
