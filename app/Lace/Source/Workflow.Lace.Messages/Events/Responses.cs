using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Workflow.Lace.Messages.Events
{
    public class ResponseReceived : IPublishableMessage
    {
        public ResponseReceived(Guid responseId, Guid requestId, DataProviderCommandSource dataProvider, DateTime date)
        {
            ResponseId = responseId;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
        }

        [DataMember]
        public Guid ResponseId { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
