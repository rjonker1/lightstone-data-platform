using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class RaisingSecurityFlagCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Category Category { get; private set; }

        public RaisingSecurityFlagCommand(Guid id, Guid requestId, string message, string payload,
            DataProviderCommandSource dataProvider,
            DateTime date, string metaData, Category category)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
            MetaData = metaData;
            Category = category;
        }
    }

    [Serializable]
    [DataContract]
    public class ConfiguringDataProviderCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Category Category { get; private set; }

        public ConfiguringDataProviderCommand(Guid id, Guid requestId, string message, string payload,
            DataProviderCommandSource dataProvider,
            DateTime date, string metaData, Category category)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
            MetaData = metaData;
            Category = category;
        }
    }

    [Serializable]
    [DataContract]
    public class TransformingDataProviderResponseCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Category Category { get; private set; }

        public TransformingDataProviderResponseCommand(Guid id, Guid requestId, string message, string payload,
            DataProviderCommandSource dataProvider,
            DateTime date, string metaData, Category category)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
            MetaData = metaData;
            Category = category;
        }
    }

    [Serializable]
    [DataContract]
    public class ErrorInDataProviderCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Category Category { get; private set; }

        public ErrorInDataProviderCommand(Guid id, Guid requestId, string message, string payload,
            DataProviderCommandSource dataProvider,
            DateTime date, string metaData, Category category)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
            MetaData = metaData;
            Category = category;
        }
    }

    [Serializable]
    [DataContract]
    public class StartingCallCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Category Category { get; private set; }

        public StartingCallCommand(Guid id, Guid requestId, string message, string payload,
            DataProviderCommandSource dataProvider,
            DateTime date, string metaData, Category category)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
            MetaData = metaData;
            Category = category;
        }
    }

    [Serializable]
    [DataContract]
    public class EndingCallCommand
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Category Category { get; private set; }

        public EndingCallCommand(Guid id, Guid requestId, string message, string payload,
            DataProviderCommandSource dataProvider,
            DateTime date, string metaData, Category category)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
            MetaData = metaData;
            Category = category;
        }
    }
}