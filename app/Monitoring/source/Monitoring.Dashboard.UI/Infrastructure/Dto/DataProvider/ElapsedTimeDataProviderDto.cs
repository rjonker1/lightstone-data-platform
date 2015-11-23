using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Models.DataProvider;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    [DataContract]public class ElapsedTimeDataProviderDto
    {
        public ElapsedTimeDataProviderDto()
        {
            
        }

        public ElapsedTimeDataProviderDto(ExecutionEnded @event)
        {
            DataProviderName = @event.Payload.MetadataObject.Results.Name;
            ElapsedTime = @event.Payload.MetadataObject.Results.ElapsedTime;
        }

        [DataMember]
        public string DataProviderName { get; set; }

        [DataMember]
        public int DataproviderId
        {
            get
            {
                return (int)(DataProviderCommandSource)Enum.Parse(typeof(DataProviderCommandSource), DataProviderName);
            }
        }

        [DataMember]
        public string ElapsedTime { get; private set; }

        [DataMember]
        public TimeSpan ElapsedTimeSpan
        {
            get
            {
                var time = new TimeSpan(0);
                TimeSpan.TryParse(ElapsedTime, out time);
                return time;
            }
        }

    }
}