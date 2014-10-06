﻿using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Dto;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration
{
    public class ConfigureAudatexRequestMessage
    {
        private readonly IProvideLaceResponse _response;
        private AudatexMessageData _audatexMessageData;

        private bool CanContinue
        {
            get
            {
                return _response.IvidResponse != null && _response.IvidResponseHandled.Handled;
            }
        }
      
        private const string MessageType = "MSGTYPE_HISTORYCHECK";

        public ConfigureAudatexRequestMessage(IProvideLaceResponse response)
        {
            _response = response;
        }

        public ConfigureAudatexRequestMessage Build()
        {
            _audatexMessageData = new AudatexMessageData()
            {
                Header = new RequestHeader(),
                Body = !CanContinue
                    ? new RequestBody()
                    : new RequestBody()
                    {
                        HistoryCheckRequest = new HistoryCheckRequestBody(_response.IvidResponse.Vin, _response.IvidResponse.License, _response.IvidResponse.Engine)
                    }
            };

            AudatexRequest = new AudatexRequest()
            {
                Message = new SerializeAuduatexRequestData(_audatexMessageData).SerializedMessage,
                MessageType = MessageType
            };

            return this;
        }

        public AudatexRequest AudatexRequest { get; private set; }

       
    }

}
