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
        private Dictionary<object, Func<ILaceRequest, IEnumerable<ILaceResponse>>> _handlers;
        private ILaceRequest _request;
        

        public Initialize Bootstrap(ILaceRequest request)
        {
            _handlers = new Dictionary<object, Func<ILaceRequest, IEnumerable<ILaceResponse>>>
            {
                {typeof(LicensePlateNumberRequest), r => LicensePlateNumberSourceChain.Build(r).Responses }
            };

            _request = request;

            return this;
        }

    }
}
