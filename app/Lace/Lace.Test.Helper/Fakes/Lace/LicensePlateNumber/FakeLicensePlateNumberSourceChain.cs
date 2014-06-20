﻿using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Test.Helper.Fakes.Lace.Consumer;

namespace Lace.Test.Helper.Fakes.Lace.LicensePlateNumber
{
    public class FakeLicensePlateNumberSourceChain
    {
        private readonly ILaceResponse _response;

        public FakeLicensePlateNumberSourceChain()
        {
            _response = new LaceResponse();
        }

        public FakeLicensePlateNumberResponse Build(ILaceRequest request, ILaceEvent laceEvent)
        {
            var handlers = new Dictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
            {
                {"Ivid", (req, evt, resp) => new FakeIvidConsumer(req).CallIvidService(resp, evt)},
                {
                    "IvidTitleHolder",
                    (req, evt, resp) => new FakeIvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp, evt)
                },
                {"RgtVin", (req, evt, resp) => new FakeRgtVinConsumer(req).CallRgtVinService(resp, evt)},
                {"Audatex", (req, evt, resp) => new FakeAudatexConsumer(req).CallAudatexService(resp, evt)}
            };

            foreach (var handler in handlers)
            {
                handler.Value(request, laceEvent, _response);
            }


            return new FakeLicensePlateNumberResponse() {Response = _response};
        }
    }

}
