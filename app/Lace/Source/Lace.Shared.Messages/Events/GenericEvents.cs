using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class ErrorThrown : IEvent
    {
        public ErrorThrown(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
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
        public object Payload { get; private set; }
    }
}
