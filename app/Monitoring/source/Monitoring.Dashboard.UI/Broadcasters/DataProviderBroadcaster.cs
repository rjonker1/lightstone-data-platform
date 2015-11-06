using System;
using System.Threading;
using Common.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
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

        private static object GetDataProviderMonitoringFromApi()
        {
            try
            {
                var handler = new DataProviderHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())),
                    new BillingTransactionRepository());
                handler.Handle(new GetMonitoringCommand(new MonitoringRequestDto()));
                return handler.MonitoringResponse;

                //var client = new HttpClient()
                //{
                //    BaseAddress = _root,
                //};
                //var model = new DataProviderDto[] { };

                //var task = client.GetAsync("dataProviders/freshenLog").ContinueWith(t =>
                //{
                //    try
                //    {
                //        var response = t.Result;
                //        var json = response.Content.ReadAsStringAsync();
                //        json.Wait();
                //        model = JsonConvert.DeserializeObject<DataProviderDto[]>(json.Result);
                //    }
                //    catch (Exception ex)
                //    {
                //        Log.ErrorFormat("Error occurred in Monitoring refreshing the data provider log because of {0}", ex.Message);
                //    }
                //});

                //task.Wait();

                //return model;
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

        private static object GetDataProviderStatisticsFromApi()
        {
            try
            {
                var handler = new DataProviderStatisticsHandler(new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes())));
                handler.Handle();
                return handler.StatisticsResponse;

                //var client = new HttpClient()
                //{
                //    BaseAddress = _root
                //};

                //var model = new DataProviderStatisticsDto[] { };

                //var task = client.GetAsync("dataProviders/freshenStatistics").ContinueWith(t =>
                //{
                //    try
                //    {
                //        var response = t.Result;
                //        var json = response.Content.ReadAsStringAsync();
                //        json.Wait();
                //        model = JsonConvert.DeserializeObject<DataProviderStatisticsDto[]>(json.Result);
                //    }
                //    catch (Exception ex)
                //    {
                //        Log.ErrorFormat("Error occurred in Monitoring refreshing the data provider stats because of {0}", ex.Message);
                //    }
                  
                //});

                //task.Wait();

                //return model;
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