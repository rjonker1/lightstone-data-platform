using System;
using Microsoft.AspNet.SignalR;
using Monitoring.Dashboard.UI.Broadcasters;

namespace Monitoring.Dashboard.UI.Hubs
{
    public class ApiRequestHub : Hub
    {
        private readonly ApiRequestBroadcaster _broadcaster;

        public ApiRequestHub()
            : this(ApiRequestBroadcaster.Instance)
        {

        }

        public ApiRequestHub(ApiRequestBroadcaster broadCaster)
        {
            _broadcaster = broadCaster;
        }

        public void InitRootUri()
        {
            _broadcaster.Root = new Uri(Context.Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}