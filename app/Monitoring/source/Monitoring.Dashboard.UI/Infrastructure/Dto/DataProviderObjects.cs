using System;

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

    public class DataProviderResponseDto
    {
        public readonly Guid Id;
        public readonly string Payload;
        public readonly DateTime Date;

        public DataProviderResponseDto(Guid id, string payLoad, DateTime date)
        {
            Id = id;
            Payload = payLoad;
            Date = date;
        }
    }
}