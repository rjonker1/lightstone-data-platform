using System;
using System.Threading;
using Common.Logging;
using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;
using DataProvider.Infrastructure.Handlers;
using DataProvider.Infrastructure.Repository;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Hubs;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class DataProviderLogBroadcaster
    {
        private static readonly Lazy<DataProviderLogBroadcaster> _instance =
            new Lazy<DataProviderLogBroadcaster>(
                () => new DataProviderLogBroadcaster(GlobalHost.ConnectionManager.GetHubContext<DataProviderLogHub>().Clients,new DataProviderHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())), new BillingTransactionRepository())));

        private static readonly ILog Log = LogManager.GetLogger<DataProviderLogBroadcaster>();

        private readonly IHubConnectionContext<dynamic> _clients;
        private Uri _root = null;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(60000);
        private Timer _monitoringTimer;
        private readonly IHandleMonitoringCommands _handler;

        public DataProviderLogBroadcaster(IHubConnectionContext<dynamic> clients, IHandleMonitoringCommands handler)
        {
            _clients = clients;
            _handler = handler;
            BroadCastDataProviderMonitoring(new {});
            SetMonitoringTimer();
        }

        private void SetMonitoringTimer()
        {
            _monitoringTimer = new Timer(BroadCastDataProviderMonitoring, null, _interval, _interval);
        }

        private void BroadCastDataProviderMonitoring(object state)
        {
            var result = GetDataProviderMonitoringFromApi();
            if (result == null)
                return;

            _clients.All.dataProviderMonitoringInfo(result);
        }

        private object GetDataProviderMonitoringFromApi()
        {
            try
            {
                //var handler = new DataProviderHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())),
                //    new BillingTransactionRepository());
                _handler.Handle(new GetMonitoringCommand(new MonitoringRequestDto()));
                return _handler.MonitoringResponse;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error occurred in Monitoring For Data Provider Broadcaster because of {0}", ex.Message);
            }
            return null;
        }

        public static DataProviderLogBroadcaster Instance
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