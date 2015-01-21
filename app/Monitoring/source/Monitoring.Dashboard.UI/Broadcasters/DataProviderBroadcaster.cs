using System;
using System.Net.Http;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Hubs;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class DataProviderBroadcaster
    {
        private static readonly Lazy<DataProviderBroadcaster> _instance =
            new Lazy<DataProviderBroadcaster>(
                () => new DataProviderBroadcaster(GlobalHost.ConnectionManager.GetHubContext<DataProviderHub>().Clients));

        private readonly IHubConnectionContext _clients;
        private Uri _root = null;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(2000);
        private readonly Timer _timer;

        public DataProviderBroadcaster(IHubConnectionContext clients)
        {
            _clients = clients;
            _timer = new Timer(BroadCastDataProviderMonitoring, null, _interval, _interval);
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

        private void BroadCastDataProviderMonitoring(object state)
        {
            var result = GetDataProviderMonitoringFromApi();
            //if (result == null)
            //    return;
            _clients.All.dataProviderMonitoringInfo();
        }

        private string GetDataProviderMonitoringFromApi()
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = _root
                };

                var response = client.GetAsync("/dataProviders/updatedLog").Result;
                return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : null;
            }
            catch (Exception)
            {
                //TODO: Log Error
            }
            return null;
        }
    }
}