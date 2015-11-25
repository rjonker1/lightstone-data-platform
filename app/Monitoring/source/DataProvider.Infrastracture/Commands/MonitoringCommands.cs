using DataProvider.Infrastructure.Dto.DataProvider;

namespace DataProvider.Infrastructure.Commands
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