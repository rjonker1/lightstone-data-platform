using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Events
{
    
    [DataContract]
    public class ResponseFromDataProvider : IPublishableMessage
    {
        public ResponseFromDataProvider(Guid id, Guid requestId, DataProviderIdentifier dataProvider, DateTime date, ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            Payload = payload;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public ConnectionTypeIdentifier Connection { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }

    }
}
