using System;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    public class MonitoringRequestDto
    {
        public readonly int SourceId;
        public readonly Guid Id;

        public MonitoringRequestDto(int source)
        {
            SourceId = source;
        }

        public MonitoringRequestDto(int source, Guid id)
        {
            Id = id;
            SourceId = source;
        }
    }
}