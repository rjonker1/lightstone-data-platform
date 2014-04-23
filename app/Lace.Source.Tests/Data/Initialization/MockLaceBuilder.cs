using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.Tests.Data.Initialization
{
    public class MockLaceBuilder : IBuild
    {
        public void BuildLicensePlateNumberRequest(IDictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
        {
            //throw new NotImplementedException();
        }
    }
}
