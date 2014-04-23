using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Handler
{
    public class LaceHandler : IHandle
    {
        public List<LaceExternalServiceResponse> LaceResponses { get; private set; }

        public void HandleRequest(ILaceRequest request,
            Dictionary<Type, Func<Request.ILaceRequest, ILaceResponse>> handlers)
        {
            foreach (var handler in handlers)
            {
                LaceResponses.Add(new LaceExternalServiceResponse()
                {
                    Response = handler.Value(request),
                    Request = request
                });
            }
        }
    }
}
