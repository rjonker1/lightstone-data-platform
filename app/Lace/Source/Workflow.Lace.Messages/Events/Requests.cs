using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Events
{

    [Serializable]
    [DataContract]
    public class RequestToDataProvider : IPublishableMessage
    {
        public RequestToDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date, string connection, string connectionType, DataProviderState state, DataProviderAction action)
        {
            Id = id;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            ConnectionType = connectionType;
            State = state;
            Action = action;
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

        [DataMember]
        public DataProviderState State { get; private set; }
        [DataMember]
        public DataProviderAction Action { get; private set; }
    }
}
