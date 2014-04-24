using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.RgtVin;
using Lace.Source.Tests.Data.Ivid;

namespace Lace.Source.Tests.Data.Initialization.LicensePlateNumber
{
    public class MockLicensePlateNumberSourceChain
    {
        private static ILaceResponse _response;

        public static MockLicensePlateNumberResponse Build(ILaceRequest request)
        {
            var handlers = new Dictionary<string, Action<ILaceRequest, ILaceResponse>>()
            {
                {"Ivid", (req, resp) => new MockIvidConsumer(req).CallIvidService(resp)} //,
                //{"IvidTitleHolder", (req, resp) => new IvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp)},
                //{"RgtVin", (req, resp) => new RgtVinConsumer(req).CallRgtVinService(resp)}
            };

            _response = new LaceResponse();
            foreach (var handler in handlers)
            {
                handler.Value(request, _response);
            }


            return new MockLicensePlateNumberResponse() { Response = _response };
        }
    }
    
    public class MockIvidTitleHolderConsumer
    {
        
    }

    public class MockRgtVinConsumer
    {
        
    }
}
