using System.Collections.Generic;
using Common.Logging;
using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Base.Services;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;

namespace DataProvider.Infrastructure.Services
{
    public class MonitoringService : ICallMonitoringService
    {
        private static readonly ILog Log = LogManager.GetLogger<MonitoringService>();
        private readonly IHandleMonitoringCommands _handler;
        private readonly IHandleDataProviderIndicators _indicatorsHandler;
        

        public MonitoringService(IHandleMonitoringCommands handler,IHandleDataProviderIndicators indicatorsHandler)
        {
            _handler = handler;
            _indicatorsHandler = indicatorsHandler;
        }

        public List<DataProviderDto> GetMonitoringForDataProviders()
        {
            Log.InfoFormat("Getting Data Provider Monitoring View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto()));
            return _handler.MonitoringResponse;
        }

        public DataProviderIndicatorsDto GetDataProviderIndicators()
        {
            Log.InfoFormat("Getting Data Provider Monitoring Indicators View");
            _indicatorsHandler.Handle();
            return _indicatorsHandler.Indicators;
        }
        
    }
}