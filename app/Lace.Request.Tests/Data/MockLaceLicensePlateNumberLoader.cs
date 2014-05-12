using System;
using System.Collections.Generic;
using Lace.Models.Request.LicensePlateNumber;
using Lace.Request.Load;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Request.Tests.Data
{
    public class MockLaceLicensePlateNumberLoader : ILoadRequestSources
    {
        public List<LaceExternalServiceResponse> LaceResponses { get; private set; }


        public MockLaceLicensePlateNumberLoader()
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
            handlers.Add(typeof (LicensePlateNumberRequest), r => MockLicensePlateNumberSourceChain.Build(r).Response);
        }
    }
}
