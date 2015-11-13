using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Commands
{
    public class GetMonitoringCommand
    {
        public readonly MonitoringRequestDto Request;

        public GetMonitoringCommand(MonitoringRequestDto request)
        {
            Request = request;
        }
    }
}