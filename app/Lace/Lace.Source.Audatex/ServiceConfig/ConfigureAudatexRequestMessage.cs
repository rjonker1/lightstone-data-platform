using Lace.Models.Audatex.Dto;
using Lace.Response;

namespace Lace.Source.Audatex.ServiceConfig
{
    public class ConfigureAudatexRequestMessage
    {
        private readonly ILaceResponse _response;
        private AudatexMessageData _audatexMessageData;

        private bool CanContinue
        {
            get
            {
                return _response.IvidResponse != null && _response.IvidResponseHandled.Handled;
            }
        }
      
        private const string MessageType = "MSGTYPE_HISTORYCHECK";

        public ConfigureAudatexRequestMessage(ILaceResponse response)
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
                        HistoryCheckRequest = new HistoryCheckRequestBody()
                        {
                            VIN = _response.IvidResponse.Vin,
                            Registration = _response.IvidResponse.License,
                            EngineNumber = _response.IvidResponse.Engine
                        }
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
