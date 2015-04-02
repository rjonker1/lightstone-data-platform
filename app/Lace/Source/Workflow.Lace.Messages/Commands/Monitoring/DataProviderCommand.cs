using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class DataProviderCommand : ICommand
    {
        [DataMember]
        public Category Category { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderCommandSource { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public object MetaData { get; private set; }

        [DataMember]
        //public string Payload { get; private set; }
        public object Payload { get; private set; }


        public DataProviderCommand(Guid id, DataProviderCommandSource dataProvider, string message, object payload,
            object metadata, DateTime date, Category category)
        {
            Id = id;
            DataProviderCommandSource = dataProvider;
            Message = message;
            Payload = payload;
            MetaData = metadata;
            Payload = payload;
            Category = category;
            Date = date;
        }
    }

  
    public interface ICommand
    {
        Category Category { get; }
        DataProviderCommandSource DataProviderCommandSource { get; }
        DateTime Date { get; }
        Guid Id { get; }
        string Message { get; }
        object MetaData { get; }
        object Payload { get; }
    }
}
