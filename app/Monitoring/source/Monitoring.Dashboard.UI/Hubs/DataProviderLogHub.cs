using System;
using Microsoft.AspNet.SignalR;
using Monitoring.Dashboard.UI.Broadcasters;

namespace Monitoring.Dashboard.UI.Hubs
{
    public class DataProviderLogHub : Hub
    {
        private readonly DataProviderLogBroadcaster _logBroadcaster;
        public DataProviderLogHub()
            : this(DataProviderLogBroadcaster.Instance)
        {

        }

        public DataProviderLogHub(DataProviderLogBroadcaster broadCaster)
        {
            _logBroadcaster = broadCaster;
        }

        public void InitRootUri()
        {
            _logBroadcaster.Root = new Uri(Context.Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}