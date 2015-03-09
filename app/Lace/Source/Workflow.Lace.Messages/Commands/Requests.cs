using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class ReceiveRequestCommand : Command
    {
        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        public ReceiveRequestCommand(Guid id, DataProviderCommandSource dataProvider, DateTime date)
            : base(id, date)
        {
            DataProvider = dataProvider;
        }
    }


    [Serializable]
    [DataContract]
    public class SendRequestToDataProviderCommand : Command
    {
        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public object RequestPayload { get; private set; }

        [DataMember]
        public string ConnectionType { get; private set; }

        [DataMember]
        public string Connection { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        public SendRequestToDataProviderCommand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, object payload,
            DateTime date, string connectionType, string connection) : base(id, date)
        {
            RequestId = requestId;
            RequestPayload = payload;
            ConnectionType = connectionType;
            Connection = connection;
            DataProvider = dataProvider;

        }
    }
}
