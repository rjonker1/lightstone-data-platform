using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class ReceiveResponseFromDataProviderCommand : Command
    {
        [DataMember]
        public Guid ResponseId { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public object ResponsePayload { get; private set; }

        public ReceiveResponseFromDataProviderCommand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date,
            Guid responseId, object payload)
            : base(id, dataProvider, date)
        {
            ResponseId = responseId;
            RequestId = requestId;
            ResponsePayload = payload;
        }
    }

    [Serializable]
    [DataContract]
    public class ReturnResponseCommmand : Command
    {
        [DataMember]
        public Guid RequestId { get; private set; }
        public ReturnResponseCommmand(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date)
            : base(id, dataProvider, date)
        {

        }
    }
}
