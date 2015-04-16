using System;
using System.Net.Http;
using System.Threading;
using Common.Logging;
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

        private readonly IHubConnectionContext<dynamic> _clients;
        private Uri _root = null;
        private TimeSpan _interval = TimeSpan.FromMilliseconds(1000);
        private Timer _timer;
        private bool _isFirstCall = true;
        private readonly ILog _log;

        public DataProviderBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _log = LogManager.GetLogger<DataProviderBroadcaster>();
            _clients = clients;
            SetTimer();
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

        private void SetTimer()
        {
            _timer = new Timer(BroadCastDataProviderMonitoring, null, _interval, _interval);
        }

        private void BroadCastDataProviderMonitoring(object state)
        {
            var result = GetDataProviderMonitoringFromApi();
            if (result == null)
                return;

            if (_isFirstCall)
            {
                _isFirstCall = false;
                _interval = TimeSpan.FromMilliseconds(60000);
                SetTimer();
            }

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

                var model = new MonitoringDataProvider[] {};

                var task = client.GetAsync("dataProviders/freshenLog").ContinueWith(t =>
                {
                    var response = t.Result;
                    var json = response.Content.ReadAsStringAsync();
                    json.Wait();
                    model = JsonConvert.DeserializeObject<MonitoringDataProvider[]>(json.Result);
                });

                task.Wait();

                return model;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error occurred in Monitoring For Data Provider Broadcaster because of {0}", ex.Message);
            }
            return null;
        }
    }
}