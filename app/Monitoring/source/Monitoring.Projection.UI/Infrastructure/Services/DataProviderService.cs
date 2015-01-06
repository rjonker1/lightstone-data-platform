using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Monitoring.Projection.UI.Core.Contracts.Handlers;
using Monitoring.Projection.UI.Core.Contracts.Services;
using Monitoring.Projection.UI.Infrastructure.Commands;
using Monitoring.Projection.UI.Infrastructure.Dto;

namespace Monitoring.Projection.UI.Infrastructure.Services
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
            _log.InfoFormat("Getting Data Provider Monitoring Information");
            _handler.Handle(
                new GetDataProviderViewRequestCommand(new DataProviderRequestDto((int) MonitoringSource.Lace)));
            return _handler.DataProviders;
        }
    }
}