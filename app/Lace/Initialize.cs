using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Request;
using Lace.Request.LicensePlateNumber.Chain;
using Lace.Request.LicensePlateNumber.Models;
using Lace.Response;

namespace Lace
{
    public class Initialize
    {
        private Dictionary<Type, Func<ILaceRequest, IEnumerable<ILaceResponse>>> _handlers;
        private ILaceRequest _request;

        public List<LaceResponse> LaceResponses { get; set; }

        public Initialize()
        {
            LaceResponses = new List<LaceResponse>();
        }

        public Initialize Bootstrap(ILaceRequest request)
        {
            _handlers = new Dictionary<Type, Func<ILaceRequest, IEnumerable<ILaceResponse>>>
            {
                {typeof(LicensePlateNumberRequest), r => LicensePlateNumberSourceChain.Build(r).Responses }
            };
            
            _request = request;
            return this;
        }

        public Initialize Load()
        {
            foreach (var handler in _handlers)
            {
                LaceResponses.Add(new LaceResponse() {Responses = handler.Value(_request), Request = _request});
            }

            return this;
        }

    }
}
