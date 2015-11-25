using System;
using System.Threading;
using Common.Logging;
using DataProvider.Infrastructure.Handlers;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Hubs;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class DataProviderIndicatorBroadcaster
    {
        private static readonly Lazy<DataProviderIndicatorBroadcaster> _instance =
           new Lazy<DataProviderIndicatorBroadcaster>(
               () => new DataProviderIndicatorBroadcaster(GlobalHost.ConnectionManager.GetHubContext<DataProviderIndicatorHub>().Clients));
        private static readonly ILog Log = LogManager.GetLogger<DataProviderIndicatorBroadcaster>();

        private Uri _root = null;
        private readonly IHubConnectionContext<dynamic> _clients;
        private Timer _indicatorTimer;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(60000);

        public DataProviderIndicatorBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;

            BroadCastDataProvideIndicators(new { });
            SetIndicatorTimer();
        }

        private void BroadCastDataProvideIndicators(object state)
        {
            var result = GetDataProviderIndicators();
            if (result == null)
                return;

            _clients.All.dataProviderIndicators(result);
        }
        private void SetIndicatorTimer()
        {
            _indicatorTimer = new Timer(BroadCastDataProvideIndicators, null, _interval, _interval);
        }

        private static object GetDataProviderIndicators()
        {
            try
            {
                var handler = new DataProviderIndicatorsHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())));
                handler.Handle();
                return handler.Indicators;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error occurred in Monitoring For Data Provider Indicator Broadcaster because of {0}", ex.Message);
            }
            return null;
        }

        public static DataProviderIndicatorBroadcaster Instance
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