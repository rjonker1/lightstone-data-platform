using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Common.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
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
        private TimeSpan _interval = TimeSpan.FromMilliseconds(60000);
        private Timer _monitoringTimer;
        private Timer _statisticsTimer;
        private bool _isFirstCall = true;
        private static readonly ILog Log = LogManager.GetLogger<DataProviderBroadcaster>();

        public DataProviderBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
            SetMonitoringTimer();
            SetStatisticsTimer();
        }

        private void SetMonitoringTimer()
        {
            _monitoringTimer = new Timer(BroadCastDataProviderMonitoring, null, _interval, _interval);
        }

        private void SetStatisticsTimer()
        {
            _statisticsTimer = new Timer(BroadCastDataProvideStatistics, null, _interval, _interval);
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
                SetMonitoringTimer();
            }

            _clients.All.dataProviderMonitoringInfo(result);
        }

        private object GetDataProviderMonitoringFromApi()
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = _root,
                  //  DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("") {  "Token bXVycmF5d0BsaWdodHN0b25lLmNvLnphDQpBY2NvdW50TWFuYWdlcnxTdXBlclVzZXJ8U3VwcG9ydHxBZG1pbnxQcm9kdWN0TWFuYWdlcg0KNjM1ODIyMTQxMTM1NDQ1NDM5DQpMaWdodHN0b25l%3AJh566ZsA2gbjfkciC5xkwgn3t8wykH72Nf6mfD03MF8%3D" }
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "Token bXVycmF5d0BsaWdodHN0b25lLmNvLnphDQpBY2NvdW50TWFuYWdlcnxTdXBlclVzZXJ8U3VwcG9ydHxBZG1pbnxQcm9kdWN0TWFuYWdlcg0KNjM1ODIyMTQxMTM1NDQ1NDM5DQpMaWdodHN0b25l%3AJh566ZsA2gbjfkciC5xkwgn3t8wykH72Nf6mfD03MF8%3D");

                var model = new DataProviderDto[] { };

                var task = client.GetAsync("dataProviders/freshenLog").ContinueWith(t =>
                {
                    try
                    {
                        var response = t.Result;
                        var json = response.Content.ReadAsStringAsync();
                        json.Wait();
                        model = JsonConvert.DeserializeObject<DataProviderDto[]>(json.Result);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("Error occurred in Monitoring refreshing the data provider log because of {0}", ex.Message);
                    }
                });

                task.Wait();

                return model;
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

            if (_isFirstCall)
            {
                _isFirstCall = false;
                _interval = TimeSpan.FromMilliseconds(60000);
                SetStatisticsTimer();
            }

            _clients.All.dataProviderStatisticsInfo(result);
        }

        private object GetDataProviderStatisticsFromApi()
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = _root
                };

                var model = new DataProviderStatisticsDto[] { };

                var task = client.GetAsync("dataProviders/freshenStatistics").ContinueWith(t =>
                {
                    try
                    {
                        var response = t.Result;
                        var json = response.Content.ReadAsStringAsync();
                        json.Wait();
                        model = JsonConvert.DeserializeObject<DataProviderStatisticsDto[]>(json.Result);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("Error occurred in Monitoring refreshing the data provider stats because of {0}", ex.Message);
                    }
                  
                });

                task.Wait();

                return model;
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