using System;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderCommand : ICommand
    {
        public Category Category { get; private set; }
        public DataProviderCommandSource DataProviderCommandSource { get; private set; }
        public DateTime Date { get; private set; }
        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public string MetaData { get; private set; }
        public string Payload { get; private set; }


        public DataProviderCommand(Guid id, DataProviderCommandSource dataProvider, string message, string payload,
            string metadata, DateTime date, Category category)
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
        Category Category { get;}
        DataProviderCommandSource DataProviderCommandSource { get;}
        DateTime Date { get;}
        Guid Id { get;}
        string Message { get;}
        string MetaData { get;}
        string Payload { get;}
    }
}
