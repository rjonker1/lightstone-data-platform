using System;
using System.Collections.Generic;
using Lace.Models.Request.LicensePlateNumber;
using Lace.Response;
using Lace.Source.Audatex;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.Repository.Product;
using Lace.Source.RgtVin;

namespace Lace.Request.Types.LicensePlateNumber.Chain
{
    public class LicensePlateNumberSourceChain
    {
        private static ILaceResponse _response;

        public static LicensePlateNumberResponse Build(ILaceRequest request)
        {
            var handlers = new Dictionary<string, Action<ILaceRequest, ILaceResponse>>()
            {
                {"ProductRepository", (req, resp) => new ProductConsumer(req).GetProduct(resp)},
                {"Ivid", (req, resp) => new IvidConsumer(req).CallIvidService(resp)},
                {"IvidTitleHolder", (req, resp) => new IvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp)},
                {"RgtVin", (req, resp) => new RgtVinConsumer(req).CallRgtVinService(resp)},
                {"Audatex", (req, resp) => new AudatexConsumer(req).CallAudatexService(resp)}
            };

            _response = new LaceResponse();
            foreach (var handler in handlers)
            {
                handler.Value(request, _response);
            }


            return new LicensePlateNumberResponse() {Response = _response};
        }
    }
}