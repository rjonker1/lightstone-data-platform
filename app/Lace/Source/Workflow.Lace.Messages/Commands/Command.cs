using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class Command
    {

        public Command(Guid id, DataProviderCommandSource dataProvider, object payload, DateTime date)
        {
            Id = id;
            DataProvider = dataProvider,
            Payload = payload;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public object Payload { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
