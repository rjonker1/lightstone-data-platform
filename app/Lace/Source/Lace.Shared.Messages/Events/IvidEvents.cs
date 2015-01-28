using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    public interface IEvent : IPublishableMessage
    {
        Category Category { get; }
        DataProviderCommandSource DataProviderCommandSource { get; }
        DateTime Date { get; }
        Guid Id { get; }
        string Message { get; }
        object MetaData { get; }
        object Payload { get; }
    }


    [Serializable]
    [DataContract]
    public class IvidExecutionHasStarted : IEvent
    {
        public IvidExecutionHasStarted(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class IvidExcutionHasEnded : IEvent
    {
        public IvidExcutionHasEnded(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }


    [Serializable]
    [DataContract]
    public class IvidDataSourceCallHasStarted : IEvent
    {
        public IvidDataSourceCallHasStarted(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class IvidDataSourceCallHasEnded : IEvent
    {
        public IvidDataSourceCallHasEnded(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class IvidSecurityFlag : IEvent
    {
        public IvidSecurityFlag(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class IvidConfigured : IEvent
    {
        public IvidConfigured(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class IvidResponseTransformed : IEvent
    {
        public IvidResponseTransformed(Guid id, DataProviderCommandSource dataProvider, string message,
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
        //public string Payload { get; private set; }
        public object Payload { get; private set; }
    }
}
