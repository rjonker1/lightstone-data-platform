using System.Collections.Generic;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
{
    public class DataProviderMonitoringService : ICallMonitoringService
    {
        private readonly ILog _log;
        private readonly IHandleMonitoringCommands _handler;

        public DataProviderMonitoringService(IHandleMonitoringCommands handler)
        {
            _log = LogManager.GetLogger<DataProviderMonitoringService>();
            _handler = handler;
        }

        public IEnumerable<MonitoringDataProviderView> GetMonitoringForDataProviders()
        {
            _log.InfoFormat("Getting Data Provider Monitoring View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto()));
            return _handler.MonitoringResponse;
        }
    }
}