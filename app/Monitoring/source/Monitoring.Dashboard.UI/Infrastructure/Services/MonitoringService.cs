using System.Collections.Generic;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
{
    public class MonitoringService : ICallMonitoringService
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly IHandleMonitoringCommands _handler;

        public MonitoringService(IHandleMonitoringCommands handler)
        {
            _handler = handler;
        }

        public IEnumerable<MonitoringResponse> GetMonitoringInformationBySource(int source)
        {
            _log.InfoFormat("Getting Monitoring View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto(source)));
            return _handler.MonitoringResponse;
        }
    }
}