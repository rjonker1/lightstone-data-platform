using System;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Events
{
    [Serializable]
    public class DataProviderCallStarted
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

        public DataProviderCallStarted()
        {

        }

        public DataProviderCallStarted(Guid requestAggregateId, DataProvider dataProvider, Category category, string message,
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
    public class DataProviderCallEnded
    {
        public readonly Guid RequestAggregateId;
        public readonly string DataProvider;
        public readonly int DataProviderId;
        public readonly string Category;
        public readonly int CategoryId;
        public readonly DateTime Date;
        public readonly string Message;
        public readonly string Payload;
        public readonly string Metadata;
        public readonly bool IsJson;


        public DataProviderCallEnded()
        {

        }

        public DataProviderCallEnded(Guid requestAggregateId, DataProvider dataProvider, Category category, string message, string payload,
            string metadata, DateTime date, bool isJson)
        {
            RequestAggregateId = requestAggregateId;
            DataProvider = dataProvider.ToString();
            DataProviderId = (int) dataProvider;
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
    public class Metadata
    {
        public string PerformanceMetadata { get; private set; }

        public void AddPerformanceMetadata(string performanceMetaData)
        {
            if (string.IsNullOrEmpty(performanceMetaData))
                return;

            PerformanceMetadata = performanceMetaData;
        }
    }
}
