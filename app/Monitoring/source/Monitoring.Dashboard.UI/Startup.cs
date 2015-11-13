using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Monitoring.Dashboard.UI.Startup))]
namespace Monitoring.Dashboard.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            TurnOfForeverFrame(GlobalHost.DependencyResolver);
            app.MapSignalR().UseNancy(x =>
            {
                x.Bootstrapper = new Bootstrapper();
                x.PerformPassThrough = context => true;
            });
        }

        public static void TurnOfForeverFrame(IDependencyResolver resolver)
        {
            var transportManager = resolver.Resolve<ITransportManager>() as TransportManager;
            transportManager.Remove("foreverFrame");
        }
    }
}
