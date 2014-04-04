using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lace.Request.LicensePlateNumber.Models;
using Lace.Response;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.RgtVin;

namespace Lace.Request.LicensePlateNumber.Chain
{
    public class LicensePlateNumberSourceChain
    {
        private static List<ILaceResponse> _responses;

        //private static LicensePlateNumberResponse Response 
        //{
        //    get
        //    {
        //        return new LicensePlateNumberResponse() { Responses = _responses }; ;
        //    }
        //}

        public static LicensePlateNumberResponse Build(ILaceRequest request)
        {
            var handlers = new Dictionary<string, Func<ILaceRequest, ILaceResponse>>()
            {
                {"Ivid", r => new IvidConsumer(r).CallIvidService()},
                {"IvidTitleHolder", r => new IvidTitleHolderConsumer(r).CallIvidTitleHolderService() },
                {"RgtVin", r => new RgtVinConsumer(r).CallRgtVinService()}
            };

            _responses = new List<ILaceResponse>();
            foreach (var handler in handlers)
            {
                _responses.Add(handler.Value(request));
            }

            return new LicensePlateNumberResponse() { Responses = _responses }; ;
        }
    }
}
