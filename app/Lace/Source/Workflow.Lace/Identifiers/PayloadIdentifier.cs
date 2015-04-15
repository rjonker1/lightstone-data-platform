using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
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

        //public PayloadIdentifier(string metaData, string payload)
        //{
        //    MetaData = metaData;
        //    Payload = payload;
        //}

        //public PayloadIdentifier(string payload)
        //{

        //    Payload = payload;
        //}

        //public PayloadIdentifier SetMessage(string message)
        //{
        //    Message = message;
        //    return this;
        //}

        //public PayloadIdentifier SetMetadata(string metaData)
        //{
        //    MetaData = metaData;
        //    return this;
        //}
    }
}
