using Lace.Models.Audatex.Dto;
using Lace.Request;

namespace Lace.Source.Audatex.ServiceConfig
{
    public class ConfigureAudatexRequestMessage
    {
        private readonly ILaceRequest _request;
        private const string MessageType = "MSGTYPE_HISTORYCHECK";

        public ConfigureAudatexRequestMessage(ILaceRequest request)
        {
            _request = request;
        }

        public AudatexRequest AudatexRequest
        {
            get
            {
                return new AudatexRequest()
                {
                   Message = new SerializeAuduatexRequestData(AudatexMessageData).SerializedMessage,
                   MessageType = MessageType
                };
            }
        }

        private AudatexMessageData AudatexMessageData
        {
            get
            {
                return new AudatexMessageData()
                {
                    Header = new RequestHeader(),
                    Body = new RequestBody()
                    {
                        HistoryCheckRequest = new HistoryCheckRequestBody()
                        {
                            VIN = _request.Vin ?? string.Empty,
                            Registration = _request.LicenceNo ?? string.Empty,
                            EngineNumber = _request.EngineNo ?? string.Empty
                        }
                    }
                };
            }
        }

       

      


    }
}
