using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.EventHandlers
{
    public class LoadEventArgs : EventArgs
    {
        public ILaceRequest Request { get; private set; }
        public Dictionary<Type, Func<ILaceRequest, ILaceResponse>> Handlers { get; private set; }

        public List<LaceExternalServiceResponse> LaceResponses { get; set; }

        public LoadEventArgs(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
        {
            Request = request;
            Handlers = handlers;
        }
    }
}
