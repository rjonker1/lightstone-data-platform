using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;

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

    public class GetMonitoringForArumentCommand
    {
        public readonly MonitoringWithArgumentDto Argument;

        public GetMonitoringForArumentCommand(MonitoringWithArgumentDto argument)
        {
            Argument = argument;
        }
    }
}