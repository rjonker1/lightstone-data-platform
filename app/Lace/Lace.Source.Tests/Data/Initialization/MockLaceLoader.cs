﻿using System;
using System.Collections.Generic;
using Lace.Events;
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

        public void HandleRequest(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> handlers, ILaceEvent laceEvent)
        {
            foreach (var handler in handlers)
            {
                LaceResponses.Add(new LaceExternalServiceResponse()
                {
                    Response = handler.Value(request, laceEvent),
                    Request = request
                });
            }
        }

        public void BuildRequest(IDictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> handlers)
        {
            handlers.Add(typeof(LicensePlateNumberRequest), (r,e) => new MockLicensePlateNumberSourceChain().Build(r,e).Response);
        }
    }
}