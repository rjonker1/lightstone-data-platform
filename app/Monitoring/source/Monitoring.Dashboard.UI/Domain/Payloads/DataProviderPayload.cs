using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Domain.Payloads 
{
    [DataContract]
    public class DataProviderPayload: AbstractPayload
    {
        public DataProviderPayload()
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
                DeserializePayload(Payload);
                return JsonPayload;
            }
        }

    }
}