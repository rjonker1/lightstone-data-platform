using System.Configuration;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cradle.KeepAlive.Service.StartupBootstrapper))]

namespace Cradle.KeepAlive.Service
{
    public class StartupBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["keepAliveScheduler"].ConnectionString);

            app.UseHangfireDashboard("/hangfire");
            app.UseNancy();
        }
    }
}
