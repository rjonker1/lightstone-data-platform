using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Request.LicensePlateNumber.Chain;
using Lace.Request.LicensePlateNumber.Models;
using Lace.Response;

namespace Lace.Builder
{
    public class LaceBuilder : IBuild
    {
        public void BuildLicensePlateNumberRequest(IDictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
        {
            handlers.Add(typeof (LicensePlateNumberRequest), r => LicensePlateNumberSourceChain.Build(r).Response);
        }
    }
}
