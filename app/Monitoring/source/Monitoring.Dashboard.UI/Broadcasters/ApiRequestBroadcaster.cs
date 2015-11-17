using System;
using System.Threading;
using Common.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Hubs;
using Monitoring.Dashboard.UI.Infrastructure.Handlers;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class ApiRequestBroadcaster
    {
        private static readonly ILog Log = LogManager.GetLogger<ApiRequestBroadcaster>();
        private static readonly Lazy<ApiRequestBroadcaster>  _instance = new Lazy<ApiRequestBroadcaster>(() => new ApiRequestBroadcaster(GlobalHost.ConnectionManager.GetHubContext<ApiRequestHub>().Clients));
        private readonly IHubConnectionContext<dynamic> _clients;

        private Timer _apiRequestTimer;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(20000);
        private Uri _root = null;
        public ApiRequestBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
            BroadcastApiRequestMetadata(new {});
            _apiRequestTimer = new Timer(BroadcastApiRequestMetadata, null, _interval, _interval);
        }

        private void BroadcastApiRequestMetadata(object state)
        {
            var result = GetRequestMetadataFromApi();
            if (result == null)
                return;

            _clients.All.apiRequestMetadataInfo(result);
        }

        private object GetRequestMetadataFromApi()
        {
            try
            {
                var handler = new ApiRequestHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())));
                handler.Handle();
                return handler.ApiRequests;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error occurred in Monitoring refreshing the api request metadata log because of {0}", ex.Message);
            }
            return null;
        }

        public static ApiRequestBroadcaster Instance
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