using System;
using Newtonsoft.Json;

namespace Monitoring.Projection.Core.Models.DataProviders
{
    public class DataProviderPerformanceDto
    {
        public readonly string DataProvider;
        public readonly string Payload;
        public readonly string Message;
        public readonly string MetaData;
        public readonly string Date;
        public readonly DateTime TimeStamp;
        public readonly Guid AggregateId;
        public string ElapsedTime;

        public DataProviderPerformanceDto(string dataProvider, string payload, string message, string metadata,
            string date, Guid aggregateId, DateTime timeStamp)
        {
            DataProvider = dataProvider;
            Payload = payload;
            Message = message;
            MetaData = metadata;
            Date = date;
            AggregateId = aggregateId;
            TimeStamp = timeStamp;
        }

        public DataProviderPerformanceDto GetElapsedTime()
        {
            if (string.IsNullOrWhiteSpace(MetaData))
                return this;

            var results = JsonConvert.DeserializeObject<ElapsedTimeResult>(MetaData);
            ElapsedTime = results.ElapsedTime;
            return this;
        }
    }

    public class DataProviderConfigurationDto
    {
        
    }

    public class DataProviderSecurityDto
    {
        
    }

    public class DataProviderFaultDto
    {
        
    }
}
