using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
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
        public string ConnectionType { get; private set; }

        [DataMember]
        public string Connection { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DataProviderAction Action { get; private set; }

        [DataMember]
        public DataProviderState State { get; private set; }

        public GetResponseFromDataProviderCommmand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date, string connection, string connectionType,
            DataProviderState state, DataProviderAction action)
        {
            Id = id;
            Date = date;
            DataProvider = dataProvider;
            RequestId = requestId;
            Connection = connection;
            ConnectionType = connectionType;
            State = state;
            Action = action;
        }
    }
}