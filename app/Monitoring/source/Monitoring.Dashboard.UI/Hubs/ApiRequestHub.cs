using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitoring.Dashboard.UI.Broadcasters;
using Monitoring.Dashboard.UI.Core.Contracts.Services;

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