using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    public class DataProviderViewDto
    {
        public readonly int SourceId;

        public DataProviderViewDto(int source)
        {
            SourceId = source;
        }
    }

    [DataContract]
    public class DataProviderResponseDto
    {
        [DataMember] public readonly Guid Id;

        [DataMember]
        //public readonly string Payload;
        public readonly object Payload;

        [DataMember] public readonly DateTime Date;

        public DataProviderResponseDto(Guid id, object payLoad, DateTime date)
        {
            Id = id;
            Payload = payLoad;
            Date = date;
        }
    }
}