using System;
using System.Net.Http;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Hubs;
using Newtonsoft.Json;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class DataProviderBroadcaster
    {
        private static readonly Lazy<DataProviderBroadcaster> _instance =
            new Lazy<DataProviderBroadcaster>(
                () => new DataProviderBroadcaster(GlobalHost.ConnectionManager.GetHubContext<DataProviderHub>().Clients));

        private readonly IHubConnectionContext _clients;
        private Uri _root = null;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(60000);
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
            if (result == null)
                return;
            _clients.All.dataProviderMonitoringInfo(result);
        }

        private object GetDataProviderMonitoringFromApi()
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = _root
                };

                var model = new MonitoringResponse[] {};

                var task = client.GetAsync("dataProviders/logSummary").ContinueWith(t =>
                {
                    var response = t.Result;
                    var json = response.Content.ReadAsStringAsync();
                    json.Wait();
                    model = JsonConvert.DeserializeObject<MonitoringResponse[]>(json.Result);
                });

                task.Wait();

                return model;
            }
            catch (Exception)
            {
                //TODO: Log Error
            }
            return null;
        }
    }
}