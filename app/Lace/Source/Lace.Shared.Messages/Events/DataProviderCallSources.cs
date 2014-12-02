using System;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    public class DataProviderEvent
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DateProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;

        public DataProviderEvent()
        {

        }

        public DataProviderEvent(Guid requestAggregateId, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int) dataProvider;
            Category = category.ToString();
            CategoryId = (int) category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class FaultInDataProviderEvent
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DateProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;

        public FaultInDataProviderEvent()
        {

        }

        public FaultInDataProviderEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
            string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int) dataProvider;
            Category = category.ToString();
            CategoryId = (int) category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class SecurityInDataProviderEvent
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DateProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;

        public SecurityInDataProviderEvent()
        {

        }

        public SecurityInDataProviderEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
            string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int) dataProvider;
            Category = category.ToString();
            CategoryId = (int) category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class ConfigurationInDataProviderEvent
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DateProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;

        public ConfigurationInDataProviderEvent()
        {

        }

        public ConfigurationInDataProviderEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
            string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int) dataProvider;
            Category = category.ToString();
            CategoryId = (int) category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class AccountingDataProviderEvent
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DateProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;

        public AccountingDataProviderEvent()
        {

        }

        public AccountingDataProviderEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
            string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int) dataProvider;
            Category = category.ToString();
            CategoryId = (int) category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class TransformationInDataProviderEvent
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DateProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;

        public TransformationInDataProviderEvent()
        {

        }

        public TransformationInDataProviderEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
            string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int) dataProvider;
            Category = category.ToString();
            CategoryId = (int) category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }
}
