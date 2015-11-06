using System;
using Microsoft.AspNet.SignalR;
using Monitoring.Dashboard.UI.Broadcasters;

namespace Monitoring.Dashboard.UI.Hubs
{
    public class DataProviderHub : Hub
    {
        private readonly DataProviderBroadcaster _broadcaster;
        public DataProviderHub()
            : this(DataProviderBroadcaster.Instance)
        {

        }

        public DataProviderHub(DataProviderBroadcaster broadCaster)
        {
            _broadcaster = broadCaster;
        }

        public void InitRootUri()
        {
            _broadcaster.Root = new Uri(Context.Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}