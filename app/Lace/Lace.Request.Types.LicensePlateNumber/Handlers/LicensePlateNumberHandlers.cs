﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;
using Lace.Events;
using Lace.Response;
using Lace.Source.Audatex;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.Repository.Product;
using Lace.Source.RgtVin;

namespace Lace.Request.Types.LicensePlateNumber.Handlers
{
    public struct LicensePlateNumberHandlers
    {
        public IDictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>> HandlersDictionary
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
                {
                    {"ProductRepository", (req, evt, resp) => new ProductConsumer(req).GetProduct(resp, evt)},
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
