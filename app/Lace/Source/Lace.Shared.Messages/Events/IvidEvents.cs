using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    [DataContract]
    public class DataProviderEvent : IPublishableMessage
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


        public DataProviderEvent(Guid id, DataProviderCommandSource dataProvider, string message, object payload,
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



    [Serializable]
    [DataContract]
    public class IvidExecutionHasStarted : DataProviderEvent
    {
        public IvidExecutionHasStarted(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidExcutionHasEnded : DataProviderEvent
    {
        public IvidExcutionHasEnded(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }


    [Serializable]
    [DataContract]
    public class IvidDataSourceCallHasStarted : DataProviderEvent
    {
        public IvidDataSourceCallHasStarted(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidDataSourceCallHasEnded : DataProviderEvent
    {
        public IvidDataSourceCallHasEnded(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidSecurityFlag : DataProviderEvent
    {
        public IvidSecurityFlag(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidConfigured : DataProviderEvent
    {
        public IvidConfigured(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidResponseTransformed : DataProviderEvent
    {
        public IvidResponseTransformed(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
}
