using System;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Lace.Identifiers
{
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

        public Guid Id { get; private set; }
        public Guid StreamId { get; private set; }
        public DateTime Date { get; private set; }
        public RequestIdentifier ParentRequest { get; private set; }
        public DataProviderIdentifier DataProvider { get; private set; }
        public ConnectionTypeIdentifier ConnectionType { get; private set; }
        public ActionIdentifier Action { get; private set; }
        public StateIdentifier State { get; private set; }

    }
}
