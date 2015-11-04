using System;
using System.Net.Http;
using System.Threading;
using Common.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Dashboard.UI.Hubs;
using Newtonsoft.Json;

namespace Monitoring.Dashboard.UI.Broadcasters
{
    public class ApiRequestBroadcaster
    {
        private static readonly ILog Log = LogManager.GetLogger<ApiRequestBroadcaster>();
        private static readonly Lazy<ApiRequestBroadcaster>  _instance = new Lazy<ApiRequestBroadcaster>(() => new ApiRequestBroadcaster(GlobalHost.ConnectionManager.GetHubContext<ApiRequestHub>().Clients));
        private readonly IHubConnectionContext<dynamic> _clients;

        private Timer _apiRequestTimer;
        private TimeSpan _interval = TimeSpan.FromMilliseconds(20000);
        private Uri _root = null;
        private bool _isFirstCall = true;
        public ApiRequestBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
            _apiRequestTimer = new Timer(BroadcastApiRequestMetadata, null, _interval, _interval);
        }

        private void BroadcastApiRequestMetadata(object state)
        {
            var result = GetRequestMetadataFromApi();
            if (result == null)
                return;

            if (_isFirstCall)
            {
                _isFirstCall = false;
                _interval = TimeSpan.FromMilliseconds(20000);
                _apiRequestTimer = new Timer(BroadcastApiRequestMetadata, null, _interval, _interval);
            }

            _clients.All.apiRequestMetadataInfo(result);
        }

        private object GetRequestMetadataFromApi()
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = _root
                };

                var model = new ApiRequestMonitoringDto[] { };
                var task = client.GetAsync("apiRequests/freshenMetadata").ContinueWith(t =>
                {
                    try
                    {
                        var response = t.Result;
                        var json = response.Content.ReadAsStringAsync();
                        json.Wait();
                        model = JsonConvert.DeserializeObject<ApiRequestMonitoringDto[]>(json.Result);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("Error occurred in Monitoring refreshing the api request metadata log because of {0}", ex.Message);
                    }
                });

                task.Wait();

                return model;
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