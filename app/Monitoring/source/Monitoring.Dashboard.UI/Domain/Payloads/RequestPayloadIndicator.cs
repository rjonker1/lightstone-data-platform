using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Domain.Payloads
{
    [DataContract]
    public class RequestPayload : AbstractPayload
    {
        public RequestPayload()
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
                DeserializePayload(Payload);
                return JsonPayload;
            }
        }

    }
}