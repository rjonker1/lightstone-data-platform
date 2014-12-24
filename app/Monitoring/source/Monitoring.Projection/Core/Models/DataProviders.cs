using System;
using Lace.Shared.Monitoring.Messages.Core;
using Newtonsoft.Json;

namespace Monitoring.Projection.Core.Models
{
    public class DataProviderPerformanceDto
    {
        public readonly string DataProvider;
        public readonly string Payload;
        public readonly string Message;
        public readonly string MetaData;
        public readonly string Date;
        public readonly Guid AggregateId;
        public TimeSpan ElapsedTime;

        public DataProviderPerformanceDto(string dataProvider, string payload, string message, string metadata,
            string date, Guid aggregateId)
        {
            DataProvider = dataProvider;
            Payload = payload;
            Message = message;
            MetaData = metadata;
            Date = date;
            AggregateId = aggregateId;
        }

        public DataProviderPerformanceDto GetElapsedTime()
        {
            if(string.IsNullOrWhiteSpace(MetaData))
                return this;

            var results = JsonConvert.DeserializeObject<StopWatchResults>(MetaData);
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
