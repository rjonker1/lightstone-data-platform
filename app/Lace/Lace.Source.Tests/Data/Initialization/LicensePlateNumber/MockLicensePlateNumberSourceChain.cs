using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source.Repository.Product;
using Lace.Source.Tests.Data.Audatex;
using Lace.Source.Tests.Data.Ivid;
using Lace.Source.Tests.Data.IvidTitleHolder;
using Lace.Source.Tests.Data.RgtVin;

namespace Lace.Source.Tests.Data.Initialization.LicensePlateNumber
{
    public class MockLicensePlateNumberSourceChain
    {
        private readonly ILaceResponse _response;

        public MockLicensePlateNumberSourceChain()
        {
            _response = new LaceResponse();
        }

        public MockLicensePlateNumberResponse Build(ILaceRequest request, ILaceEvent laceEvent)
        {
            var handlers = new Dictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
            {
                {"ProductRepository", (req, evt, resp) => new ProductConsumer(req).GetProduct(resp,evt)},
                {"Ivid", (req, evt, resp) => new MockIvidConsumer(req).CallIvidService(resp,evt)},
                {
                    "IvidTitleHolder",
                    (req, evt, resp) => new MockIvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp,evt)
                },
                {"RgtVin", (req, evt, resp) => new MockRgtVinConsumer(req).CallRgtVinService(resp,evt)},
                {"Audatex", (req, evt, resp) => new MockAudatexConsumer(req).CallAudatexService(resp,evt)}
            };

            foreach (var handler in handlers)
            {
                handler.Value(request, laceEvent, _response);
            }


            return new MockLicensePlateNumberResponse() {Response = _response};
        }
    }

}
