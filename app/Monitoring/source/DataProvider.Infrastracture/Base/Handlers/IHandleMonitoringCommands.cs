using System.Collections.Generic;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;

namespace DataProvider.Infrastructure.Base.Handlers
{
    public interface IHandleMonitoringCommands
    {
        List<DataProviderDto> MonitoringResponse { get; }
        void Handle(GetMonitoringCommand command);
        void Handle(GetMonitoringForArumentCommand command);
    }
}
