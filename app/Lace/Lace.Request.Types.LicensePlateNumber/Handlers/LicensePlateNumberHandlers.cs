using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Response;
using Lace.Source.Audatex;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.RgtVin;

namespace Lace.Request.Types.LicensePlateNumber.Handlers
{
    public struct LicensePlateNumberHandlers
    {
        public IDictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>> Handlers
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
                {
                    {"Ivid", (req, evt, resp) => new IvidConsumer(req).CallIvidService(resp, evt)},
                    {
                        "IvidTitleHolder",
                        (req, evt, resp) =>
                            new IvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp, evt)
                    },
                    {"RgtVin", (req, evt, resp) => new RgtVinConsumer(req).CallRgtVinService(resp, evt)},
                    {"Audatex", (req, evt, resp) => new AudatexConsumer(req).CallAudatexService(resp, evt)}
                };
            }
        }
    }
}
