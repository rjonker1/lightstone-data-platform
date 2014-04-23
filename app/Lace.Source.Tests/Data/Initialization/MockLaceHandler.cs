using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Source.Tests.Data.Initialization
{
    public class MockLaceHandler : IHandle
    {
        public List<LaceExternalServiceResponse> LaceResponses { get; private set; }

        public void HandleRequest(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
        {
           // throw new NotImplementedException();
            LaceResponses= new List<LaceExternalServiceResponse>();
        }
    }
}
