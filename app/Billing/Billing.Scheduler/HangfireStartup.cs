using System.Configuration;
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
            ConnectionStringSettings connString;

            GlobalConfiguration.Configuration
            .UseLogProvider(new ColouredConsoleLogProvider())
            .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["billingScheduler"].ConnectionString);

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}