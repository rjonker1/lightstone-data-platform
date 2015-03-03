using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Workflow.Lace.Messages.Events
{
    [Serializable]
    [DataContract]
    public class RequestReceived : IPublishableMessage
    {
        public RequestReceived(Guid requestId, DataProviderCommandSource dataProvider, DateTime date)
        {
            RequestId = requestId;
            DataProvider = dataProvider,
            Date = date;
        }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
