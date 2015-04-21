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
        private readonly IHandleDataProviderStatistics _statisticsHandler;

        public DataProviderMonitoringService(IHandleMonitoringCommands handler,
            IHandleDataProviderStatistics statisticsHandler)
        {
            _log = LogManager.GetLogger<DataProviderMonitoringService>();
            _handler = handler;
            _statisticsHandler = statisticsHandler;
        }

        public IEnumerable<DataProviderView> GetMonitoringForDataProviders()
        {
            _log.InfoFormat("Getting Data Provider Monitoring View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto()));
            return _handler.MonitoringResponse;
        }

        public IEnumerable<DataProviderStatisticsView> GetDataProviderStatistics()
        {
            _log.InfoFormat("Getting Data Provider Monitoring Statistics View");
            _statisticsHandler.Handle();
            return _statisticsHandler.StatisticsResponse;
        }
    }
}