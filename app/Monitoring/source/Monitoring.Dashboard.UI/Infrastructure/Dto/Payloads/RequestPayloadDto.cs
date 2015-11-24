using System;
using System.Runtime.Serialization;
using Monitoring.Domain;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.Payloads
{
    [DataContract]
    public class RequestPayloadDto : AbstractDto
    {
        public RequestPayloadDto()
        {

        }

        [DataMember]
        public byte[] Payload { get; set; }

        [DataMember]
        public Guid RequestId { get; set; }

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