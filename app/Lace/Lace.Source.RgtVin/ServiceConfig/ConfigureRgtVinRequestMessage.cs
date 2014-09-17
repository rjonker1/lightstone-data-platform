﻿using Lace.Models.Responses;
using Lace.Models.RgtVin.Dto;
using Lace.Request;

namespace Lace.Source.RgtVin.ServiceConfig
{
    public class ConfigureRgtVinRequestMessage
    {
        public RgtVinRequest RgtVinRequest { get; private set; }
        private readonly ILaceRequest _request;
        private readonly ILaceResponse _response;


        public ConfigureRgtVinRequestMessage(ILaceRequest request, ILaceResponse response)
        {
            _request = request;
            _response = response;
        }

        public ConfigureRgtVinRequestMessage Build()
        {
            RgtVinRequest = new RgtVinRequest(_response.IvidResponse != null && _response.IvidResponseHandled.Handled
                ? _response.IvidResponse.Vin
                : string.Empty, _request.Context.SecurityCode);


            return this;
        }
    }
}
