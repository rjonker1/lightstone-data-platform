using System;
using Microsoft.AspNet.SignalR;
using Monitoring.Dashboard.UI.Broadcasters;

namespace Monitoring.Dashboard.UI.Hubs
{
    public class DataProviderErrorLogHub : Hub
    {
        private readonly DataProviderErrorLogBroadcaster _logBroadcaster;
        public DataProviderErrorLogHub()
            : this(DataProviderErrorLogBroadcaster.Instance)
        {

        }

        public DataProviderErrorLogHub(DataProviderErrorLogBroadcaster broadCaster)
        {
            _logBroadcaster = broadCaster;
        }

        public void InitRootUri()
        {
            _logBroadcaster.Root = new Uri(Context.Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}