﻿using System;
using System.Collections.Generic;
using Lace.Models.Request.LicensePlateNumber;
using Lace.Request.Types.LicensePlateNumber.Chain;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Request.Load.Loaders
{
    public class LaceLicensePlateNumberLoader : ILoadRequestSources
    {
        public List<LaceExternalServiceResponse> LaceResponses { get; private set; }

        public LaceLicensePlateNumberLoader()
        {
            LaceResponses = new List<LaceExternalServiceResponse>();
        }

        public void HandleRequest(ILaceRequest request,
            Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
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
            handlers.Add(typeof (LicensePlateNumberRequest), r => new LicensePlateNumberSourceChain().Build(r).Response);
        }
    }
}
