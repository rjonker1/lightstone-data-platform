using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class ReceiveRequestCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        public ReceiveRequestCommand(Guid id, DataProviderCommandSource dataProvider, DateTime date)
        {
            Id = id;
            Date = date;
            DataProvider = dataProvider;
        }
    }


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
        public object RequestPayload { get; private set; }

        [DataMember]
        public string ConnectionType { get; private set; }

        [DataMember]
        public string Connection { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        public SendRequestToDataProviderCommand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, object payload,
            DateTime date, string connectionType, string connection)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            RequestPayload = payload;
            ConnectionType = connectionType;
            Connection = connection;
            DataProvider = dataProvider;

        }
    }
}
