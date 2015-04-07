using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

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
        public object Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        public RaisingSecurityFlagCommand(Guid id, Guid requestId, string message, object payload, DataProviderCommandSource dataProvider,
            DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
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
        public object Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        public ConfiguringDataProviderCommand(Guid id, Guid requestId, string message, object payload, DataProviderCommandSource dataProvider,
            DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
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
        public object Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        public TransformingDataProviderResponseCommand(Guid id, Guid requestId, string message, object payload, DataProviderCommandSource dataProvider,
            DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
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
        public object Payload { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        public ErrorInDataProviderCommand(Guid id, Guid requestId, string message, object payload, DataProviderCommandSource dataProvider,
            DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Message = message;
            Payload = payload;
            DataProvider = dataProvider;
            Date = date;
        }
    }
}