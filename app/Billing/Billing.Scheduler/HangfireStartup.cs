using Hangfire;
using Hangfire.Logging.LogProviders;
using Microsoft.Owin;
using Nancy;
using Owin;

[assembly: OwinStartup(typeof(Billing.Scheduler.HangfireStartup))]

namespace Billing.Scheduler
{
    public class HangfireStartup : DefaultNancyBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            .UseLogProvider(new ColouredConsoleLogProvider())
            .UseSqlServerStorage(@"Server=.;Database=Billing.Scheduler; Integrated Security=SSPI;");

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}