using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class DataProviderTransactionIdentifier
    {
        public DataProviderTransactionIdentifier()
        {

        }

        public DataProviderTransactionIdentifier(Guid id, Guid streamId, DateTime date, RequestIdentifier parentRequest,
            DataProviderIdentifier dataProvider, ConnectionTypeIdentifier connectionType, ActionIdentifier action,
            StateIdentifier state)
        {
            Id = id;
            StreamId = streamId;
            Date = date;
            ParentRequest = parentRequest;
            DataProvider = dataProvider;
            ConnectionType = connectionType;
            Action = action;
            State = state;
        }

        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public Guid StreamId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public RequestIdentifier ParentRequest { get; private set; }
        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }
        [DataMember]
        public ConnectionTypeIdentifier ConnectionType { get; private set; }
        [DataMember]
        public ActionIdentifier Action { get; private set; }
        [DataMember]
        public StateIdentifier State { get; private set; }

    }
}
