using System;
using Newtonsoft.Json;

namespace Monitoring.Projection.Core.Models.DataProviders
{
    public class DataProviderDto
    {
        public readonly int DataProviderId;
        public readonly int CategoryId;
        public readonly string Category;
        public readonly string DataProvider;
        public readonly string Payload;
        public readonly string Message;
        public readonly string MetaData;
        public readonly DateTime Date;
        public readonly DateTime TimeStamp;
        public readonly Guid AggregateId;
        public readonly bool IsPerformance;
        public string ElapsedTime;

        public DataProviderDto(string dataProvider, int dataProviderId, string category, int categoryId, string payload,
            string message, string metadata,
            DateTime date, Guid aggregateId, DateTime timeStamp)
        {
            DataProvider = dataProvider;
            DataProviderId = dataProviderId;
            Category = category;
            CategoryId = categoryId;
            Payload = payload;
            Message = message;
            MetaData = metadata;
            Date = date;
            AggregateId = aggregateId;
            TimeStamp = timeStamp;
            IsPerformance = Category.Equals("Performance", StringComparison.CurrentCultureIgnoreCase);
        }

        public DataProviderDto GetElapsedTime()
        {
            if (string.IsNullOrWhiteSpace(MetaData))
                return this;

            var results = JsonConvert.DeserializeObject<ElapsedTimeResult>(MetaData);
            ElapsedTime = results.ElapsedTime;
            return this;
        }
    }
}
