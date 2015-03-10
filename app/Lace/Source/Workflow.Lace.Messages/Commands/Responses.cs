using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class ReceiveResponseFromDataProviderCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        //[DataMember]
        //public object ResponsePayload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        public ReceiveResponseFromDataProviderCommand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            DataProvider = dataProvider;
        }
    }

    [Serializable]
    [DataContract]
    public class ReturnResponseCommmand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        //[DataMember]
        //public object ResponsePayload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }
        public ReturnResponseCommmand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date)
        {
            Id = id;
            Date = date;
            DataProvider = dataProvider;
            RequestId = requestId;
            //ResponsePayload = payload;
        }
    }
}
