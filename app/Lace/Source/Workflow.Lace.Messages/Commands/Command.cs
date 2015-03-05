using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class Command
    {

        public Command(Guid id, DataProviderCommandSource dataProvider, DateTime date)
        {
            Id = id;
            DataProvider = dataProvider;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
