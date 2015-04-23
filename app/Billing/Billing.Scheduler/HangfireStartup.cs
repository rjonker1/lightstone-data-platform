using Hangfire;
using Hangfire.Logging.LogProviders;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Billing.Scheduler.HangfireStartup))]

namespace Billing.Scheduler
{
    public class HangfireStartup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            .UseLogProvider(new ColouredConsoleLogProvider())
            .UseSqlServerStorage(@"Server=.;Database=Hangfire.Test; Integrated Security=SSPI;");

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}