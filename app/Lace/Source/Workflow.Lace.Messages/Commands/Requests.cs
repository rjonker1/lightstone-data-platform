using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
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
        public string ConnectionType { get; private set; }

        [DataMember]
        public string Connection { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DataProviderAction Action { get; private set; }
        [DataMember]
        public DataProviderState State { get; private set; }

        public SendRequestToDataProviderCommand(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, string connectionType, string connection, DataProviderAction action, DataProviderState state)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            ConnectionType = connectionType;
            Connection = connection;
            DataProvider = dataProvider;
            Action = action;
            State = state;

        }
    }
}
