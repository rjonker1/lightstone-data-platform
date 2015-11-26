using System;
using Microsoft.AspNet.SignalR;
using Monitoring.Dashboard.UI.Broadcasters;

namespace Monitoring.Dashboard.UI.Hubs
{
    public class DataProviderIndicatorHub : Hub
    {
        private readonly DataProviderIndicatorBroadcaster _broadcaster;
        public DataProviderIndicatorHub()
            : this(DataProviderIndicatorBroadcaster.Instance)
        {

        }

        public DataProviderIndicatorHub(DataProviderIndicatorBroadcaster broadCaster)
        {
            _broadcaster = broadCaster;
        }

        public void InitRootUri()
        {
            _broadcaster.Root = new Uri(Context.Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}