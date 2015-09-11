using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cradle.KeepAlive.Service.StartupBootstrapper))]

namespace Cradle.KeepAlive.Service
{
    public class StartupBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
