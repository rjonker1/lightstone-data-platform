using System;
using System.Threading;
using Common.Logging;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;
using DataProvider.Infrastructure.Handlers;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Hubs;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class DataProviderErrorLogBroadcaster
    {
        private static readonly Lazy<DataProviderErrorLogBroadcaster> _instance =
            new Lazy<DataProviderErrorLogBroadcaster>(
                () => new DataProviderErrorLogBroadcaster(GlobalHost.ConnectionManager.GetHubContext<DataProviderErrorLogHub>().Clients));

        private static readonly ILog Log = LogManager.GetLogger<DataProviderErrorLogBroadcaster>();


        private Uri _root = null;
        private readonly IHubConnectionContext<dynamic> _clients;
        private Timer _indicatorTimer;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(30000);

        public DataProviderErrorLogBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;

            BroadCastDataProviderErrors(new {});
            SetErrorLogTimer();
        }

        private void BroadCastDataProviderErrors(object state)
        {
            var result = GetDataProviderErrors();
            if (result == null)
                return;

            _clients.All.dataProviderErrors(result);
        }

        private void SetErrorLogTimer()
        {
            _indicatorTimer = new Timer(BroadCastDataProviderErrors, null, _interval, _interval);
        }

        private static object GetDataProviderErrors()
        {
            try
            {
                var handler = new DataProviderErrorHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())));
                handler.Handle(new GetMonitoringCommand(new MonitoringRequestDto()));
                return handler.ErrorResponse;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error occurred in Monitoring For Data Provider Error Broadcaster because of {0}", ex.Message);
            }
            return null;
        }

        public static DataProviderErrorLogBroadcaster Instance
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