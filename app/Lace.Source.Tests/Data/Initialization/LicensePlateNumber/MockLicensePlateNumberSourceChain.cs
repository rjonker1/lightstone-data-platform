using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;
using Lace.Source.Tests.Data.Audatex;
using Lace.Source.Tests.Data.Ivid;
using Lace.Source.Tests.Data.IvidTitleHolder;
using Lace.Source.Tests.Data.RgtVin;

namespace Lace.Source.Tests.Data.Initialization.LicensePlateNumber
{
    public class MockLicensePlateNumberSourceChain
    {
        private static ILaceResponse _response;

        public static MockLicensePlateNumberResponse Build(ILaceRequest request)
        {
            var handlers = new Dictionary<string, Action<ILaceRequest, ILaceResponse>>()
            {
                {"Ivid", (req, resp) => new MockIvidConsumer(req).CallIvidService(resp)},
                {
                    "IvidTitleHolder",
                    (req, resp) => new MockIvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp)
                },
                {"RgtVin", (req, resp) => new MockRgtVinConsumer(req).CallRgtVinService(resp)},
                {"Audatex", (req, resp) => new MockAudatexConsumer(req).CallAudatexService(resp)}
            };

            _response = new LaceResponse();
            foreach (var handler in handlers)
            {
                handler.Value(request, _response);
            }


            return new MockLicensePlateNumberResponse() {Response = _response};
        }
    }

}
