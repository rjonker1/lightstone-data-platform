using System;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    public interface IDataProviderEvent
    {
        
    }

    public interface IDataProviderNotUsedEvent
    {
        
    }

    [Serializable]
    public class DataProviderEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderExecutingEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderHasExecutedEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderIsCalledEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderCallEndedEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderHasFaultEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderHasSecurityEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderHasConfigurationEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class AccountingDataProviderEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
    public class DataProviderasBeenTransformedEvent : IDataProviderEvent
    {
        public Guid RequestAggregateId { get; private set; }
        public string DataProvider { get; private set; }
        public int DateProviderId { get; private set; }
        public string Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public string Metadata { get; private set; }
        public bool IsJson { get; private set; }

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
