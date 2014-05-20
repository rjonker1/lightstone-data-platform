﻿using System;
using System.Collections.Generic;
using Lace.Events;
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
            handlers.Add(typeof (LicensePlateNumberRequest), (r,e) => new MockLicensePlateNumberSourceChain().Build(r,e).Response);
        }
    }
}