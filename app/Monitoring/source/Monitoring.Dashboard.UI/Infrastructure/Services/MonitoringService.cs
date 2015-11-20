﻿using System.Collections.Generic;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
{
    public class MonitoringService : ICallMonitoringService
    {
        private static readonly ILog Log = LogManager.GetLogger<MonitoringService>();
        private readonly IHandleMonitoringCommands _handler;
        private readonly IHandleDataProviderStatistics _statisticsHandler;
        

        public MonitoringService(IHandleMonitoringCommands handler,IHandleDataProviderStatistics statisticsHandler)
        {
            _handler = handler;
            _statisticsHandler = statisticsHandler;
        }

        public List<DataProviderDto> GetMonitoringForDataProviders()
        {
            Log.InfoFormat("Getting Data Provider Monitoring View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto()));
            return _handler.MonitoringResponse;
        }

        public List<DataProviderStatisticsDto> GetDataProviderStatistics()
        {
            Log.InfoFormat("Getting Data Provider Monitoring Statistics View");
            _statisticsHandler.Handle();
            return _statisticsHandler.StatisticsResponse;
        }
        
    }
}