using System;
using System.Collections.Generic;
using Lace.Models.Request.LicensePlateNumber;
using Lace.Request;
using Lace.Request.Load;
using Lace.Response;
using Lace.Response.ExternalServices;
using Lace.Source.Tests.Data.Initialization.LicensePlateNumber;

namespace Lace.Source.Tests.Data.Initialization
{
    public class MockLaceLoader : ILoadRequestSources
    {
        public List<LaceExternalServiceResponse> LaceResponses { get; private set; }


        public MockLaceLoader()
        {
            LaceResponses = new List<LaceExternalServiceResponse>();
        }

        public void HandleRequest(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
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

        public void BuildRequest(IDictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
        {
            handlers.Add(typeof(LicensePlateNumberRequest), r => MockLicensePlateNumberSourceChain.Build(r).Response);
        }
    }
}
