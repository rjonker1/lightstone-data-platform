using System;
using System.Runtime.Serialization;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Commands
{
    
    [DataContract]
    public class SendRequestToDataProviderCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public ConnectionTypeIdentifier Connection { get; private set; }

        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }

        public SendRequestToDataProviderCommand(Guid id, Guid requestId, DataProviderIdentifier dataProvider,
            DateTime date, ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Connection = connection;
            DataProvider = dataProvider;
            Payload = payload;
        }
    }
}
