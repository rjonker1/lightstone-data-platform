using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Workflow.Lace.Messages.Events
{
    public class ResponseReceivedFromDataProvider : IPublishableMessage
    {
        public ResponseReceivedFromDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date)
        {
            Id = id;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }

    public class ResponseReturned : IPublishableMessage
    {
        public ResponseReturned(Guid id, Guid requestId, DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
