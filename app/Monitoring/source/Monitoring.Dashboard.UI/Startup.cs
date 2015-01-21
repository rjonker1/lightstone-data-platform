using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Monitoring.Dashboard.UI.Startup))]

namespace Monitoring.Dashboard.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR().UseNancy();
        }
    }
}
