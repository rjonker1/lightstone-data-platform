using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Dto;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration
{
    public class ConfigureAudatexRequestMessage
    {
        private readonly ICollection<IPointToLaceProvider> _response;
        private AudatexMessageData _audatexMessageData;

        private bool CanContinue
        {
            get
            {
                return _response.OfType<IProvideDataFromIvid>().First() != null;
            }
        }

        private const string MessageType = "MSGTYPE_HISTORYCHECK";

        public ConfigureAudatexRequestMessage(ICollection<IPointToLaceProvider> response)
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
                        HistoryCheckRequest =
                            new HistoryCheckRequestBody(_response.OfType<IProvideDataFromIvid>().First().Vin,
                                _response.OfType<IProvideDataFromIvid>().First().License,
                                _response.OfType<IProvideDataFromIvid>().First().Engine)
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
