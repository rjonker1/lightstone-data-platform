﻿using System;
using System.Collections.Generic;
using Lace.Request.LicensePlateNumber.Models;
using Lace.Response;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.RgtVin;

namespace Lace.Request.LicensePlateNumber.Chain
{
    public class LicensePlateNumberSourceChain
    {
        //private static List<ILaceResponse> _responses;

        private static ILaceResponse _response;

        public static LicensePlateNumberResponse Build(ILaceRequest request)
        {
            var handlers = new Dictionary<string, Func<ILaceRequest, ILaceResponse, bool>>()
            {
                {"Ivid", (req,resp) => new IvidConsumer(req).CallIvidService(resp)},
                {"IvidTitleHolder", (req,resp) => new IvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp)},
                {"RgtVin", (req,resp) => new RgtVinConsumer(req).CallRgtVinService(resp)}
            };

            _response = new LaceResponse();
            foreach (var handler in handlers)
            {
                handler.Value(request, _response);
            }

           
            //_responses = new List<ILaceResponse>();
            //foreach (var handler in handlers)
            //{
            //    _responses.Add(handler.Value(request));
            //}

            return new LicensePlateNumberResponse() { Response = _response };
        }
    }
}
