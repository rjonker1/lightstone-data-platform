using System;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    public interface IDomainEvent
    {
        
    }

    [Serializable]
    public class DataProviderEvent : IDomainEvent
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
    public class DataProviderExecutingEvent : IDomainEvent
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

        public DataProviderExecutingEvent()
        {

        }

        public DataProviderExecutingEvent(Guid requestAggregateId, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int)dataProvider;
            Category = category.ToString();
            CategoryId = (int)category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class DataProviderHasExecutedEvent : IDomainEvent
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

        public DataProviderHasExecutedEvent()
        {

        }

        public DataProviderHasExecutedEvent(Guid requestAggregateId, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int)dataProvider;
            Category = category.ToString();
            CategoryId = (int)category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class DataProviderIsCalledEvent : IDomainEvent
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

        public DataProviderIsCalledEvent()
        {

        }

        public DataProviderIsCalledEvent(Guid requestAggregateId, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DateProviderId = (int)dataProvider;
            Category = category.ToString();
            CategoryId = (int)category;
            Message = message;
            Payload = payload;
            Date = date;
            Metadata = metadata;
            IsJson = isJson;
        }
    }

    [Serializable]
    public class DataProviderCallEndedEvent : IDomainEvent
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

        public DataProviderCallEndedEvent()
        {

        }

        public DataProviderCallEndedEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
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
    public class DataProviderHasFaultEvent : IDomainEvent
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

        public DataProviderHasFaultEvent()
        {

        }

        public DataProviderHasFaultEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
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
    public class DataProviderHasSecurityEvent : IDomainEvent
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

        public DataProviderHasSecurityEvent()
        {

        }

        public DataProviderHasSecurityEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
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
    public class DataProviderHasConfigurationEvent : IDomainEvent
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

        public DataProviderHasConfigurationEvent()
        {

        }

        public DataProviderHasConfigurationEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
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
    public class AccountingDataProviderEvent : IDomainEvent
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
    public class DataProviderasBeenTransformedEvent : IDomainEvent
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

        public DataProviderasBeenTransformedEvent()
        {

        }

        public DataProviderasBeenTransformedEvent(Guid requestAggregateId, DataProvider dataProvider, Category category,
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
