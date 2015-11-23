using System;
using System.Threading;
using Common.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;
using Monitoring.Dashboard.UI.Hubs;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class DataProviderBroadcaster
    {
        private static readonly Lazy<DataProviderBroadcaster> _instance =
            new Lazy<DataProviderBroadcaster>(
                () => new DataProviderBroadcaster(GlobalHost.ConnectionManager.GetHubContext<DataProviderHub>().Clients));

        private readonly IHubConnectionContext<dynamic> _clients;
        private Uri _root = null;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(60000);
        private readonly TimeSpan _statsInterval = TimeSpan.FromMilliseconds(25000);
        private Timer _monitoringTimer;
        private Timer _statisticsTimer;
        private static readonly ILog Log = LogManager.GetLogger<DataProviderBroadcaster>();

        public DataProviderBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;

            BroadCastDataProvideStatistics(new {});
            BroadCastDataProviderMonitoring(new {});

            SetMonitoringTimer();
            SetStatisticsTimer();
        }

        private void SetMonitoringTimer()
        {
            _monitoringTimer = new Timer(BroadCastDataProviderMonitoring, null, _interval, _interval);
        }

        private void SetStatisticsTimer()
        {
            _statisticsTimer = new Timer(BroadCastDataProvideStatistics, null, _statsInterval, _interval);
        }

        private void BroadCastDataProviderMonitoring(object state)
        {
            var result = GetDataProviderMonitoringFromApi();
            if (result == null)
                return;

            _clients.All.dataProviderMonitoringInfo(result);
        }

        private static object GetDataProviderMonitoringFromApi()
        {
            try
            {
                var handler = new DataProviderHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())),
                    new BillingTransactionRepository());
                handler.Handle(new GetMonitoringCommand(new MonitoringRequestDto()));
                return handler.MonitoringResponse;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error occurred in Monitoring For Data Provider Broadcaster because of {0}", ex.Message);
            }
            return null;
        }

        private void BroadCastDataProvideStatistics(object state)
        {
            var result = GetDataProviderStatisticsFromApi();
            if (result == null)
                return;

            _clients.All.dataProviderStatisticsInfo(result);
        }

        private static object GetDataProviderStatisticsFromApi()
        {
            try
            {
                var handler = new DataProviderIndicatorsHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())));
                handler.Handle();
                return handler.Indicators;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error occurred in Monitoring For Data Provider Statistics Broadcaster because of {0}", ex.Message);
            }
            return null;
        }

        public static DataProviderBroadcaster Instance
        {
            get { return _instance.Value; }
        }

        public Uri Root
        {
            set
            {
                if (_root == null)
                    _root = value;
            }
        }
    }
}