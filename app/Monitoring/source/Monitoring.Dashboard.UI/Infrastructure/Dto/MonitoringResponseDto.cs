using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    [DataContract]
    public class MonitoringResponseDto
    {
        [DataMember] public readonly Guid Id;

        [DataMember]
        public readonly object Payload;

        [DataMember] public readonly DateTime Date;

        public MonitoringResponseDto(Guid id, object payLoad, DateTime date)
        {
            Id = id;
            Payload = payLoad;
            Date = date;
        }
    }
}