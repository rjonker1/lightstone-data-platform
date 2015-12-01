using System;
using System.Runtime.Serialization;
using EasyNetQ;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Commands
{
    [Queue("DataPlatform.DataProvider.Sender", ExchangeName = "DataPlatform.DataProvider.Sender")]
    [DataContract]
    public class GetResponseFromDataProviderCommmand
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
        [DataMember]
        public string ReferenceNumber { get; private set; }

        public GetResponseFromDataProviderCommmand(Guid id, Guid requestId, DataProviderIdentifier dataProvider,
            DateTime date, ConnectionTypeIdentifier connection, PayloadIdentifier payload, string referenceNumber)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Connection = connection;
            DataProvider = dataProvider;
            Payload = payload;
            ReferenceNumber = referenceNumber;
        }
    }
}