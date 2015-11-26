using System.Runtime.Serialization;
using Monitoring.Domain;

namespace DataProvider.Infrastructure.Dto.Payloads
{
    [DataContract]
    public class DataProviderPayloadDto: AbstractDto
    {
        public DataProviderPayloadDto()
        {

        }

        [DataMember]
        public byte[] Payload { get; set; }

        [DataMember]
        public int DataProviderId { get; set; }

        [DataMember]
        public string Json
        {
            get
            {
                Deserialize(Payload);
                return JsonPayload;
            }
        }

    }
}