using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;

namespace Lace
{
    public interface IBuild
    {
        void BuildLicensePlateNumberRequest(IDictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers);
    }
}
