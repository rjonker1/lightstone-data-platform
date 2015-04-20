using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [DataContract]
    public class PayloadIdentifier
    {
        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        public PayloadIdentifier(string metaData, string payload, string message)
        {
            MetaData = metaData;
            Payload = payload;
            Message = message;
        }
    }
}
