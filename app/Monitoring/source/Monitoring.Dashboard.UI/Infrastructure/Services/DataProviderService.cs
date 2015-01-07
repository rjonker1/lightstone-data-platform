using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
{
    public class DataProviderService : ICallDataProviderService
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly IHandleDataProviderCommands _handler;

        public DataProviderService(IHandleDataProviderCommands handler)
        {
            _handler = handler;
        }

        public IEnumerable<DataProviderResponseDto> GetDataProviderMonitoringInformation()
        {
            _log.InfoFormat("Getting Data Provider Monitoring View");
            _handler.Handle(
                new GetDataProviderViewCommand(new DataProviderViewDto((int) MonitoringSource.Lace)));
            return _handler.DataProviders;
        }
    }
}