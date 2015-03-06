using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Workflow.Lace.Messages.Events
{
    [Serializable]
    [DataContract]
    public class RequestReceived : IPublishableMessage
    {
        public RequestReceived(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class RequestSentToDataProvider : IPublishableMessage
    {
        public RequestSentToDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date, string connection, string connectionType)
        {
            Id = id;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            ConnectionType = connectionType;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public string ConnectionType { get; private set; }

        [DataMember]
        public string Connection { get; private set; }
    }
}
