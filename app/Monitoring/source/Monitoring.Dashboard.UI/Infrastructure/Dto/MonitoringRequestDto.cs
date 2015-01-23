using System;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    public class MonitoringRequestDto
    {
        public readonly int SourceId;
        public MonitoringRequestDto(int source)
        {
            SourceId = source;
        }

    }
}