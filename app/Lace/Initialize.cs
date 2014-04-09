using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Request.LicensePlateNumber.Chain;
using Lace.Request.LicensePlateNumber.Models;
using Lace.Response;

namespace Lace
{
    public class Initialize
    {
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;
        private ILaceRequest _request;

        public List<LaceServiceResponse> LaceResponses { get; set; }

        public Initialize()
        {
            LaceResponses = new List<LaceServiceResponse>();
        }

        public Initialize Bootstrap(ILaceRequest request)
        {
            _handlers = new Dictionary<Type, Func<ILaceRequest, ILaceResponse>>
            {
                {typeof(LicensePlateNumberRequest), r => LicensePlateNumberSourceChain.Build(r).Response }
            };

            _request = request;
            return this;
        }


        public Initialize Load()
        {
            foreach (var handler in _handlers)
            {
                LaceResponses.Add(new LaceServiceResponse() {Response = handler.Value(_request), Request = _request});
            }

            return this;
        }

    }
}
