using System.Configuration;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Workflow.Billing.Scheduler.Service.Startup))]

namespace Workflow.Billing.Scheduler.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["billingScheduler"].ConnectionString);

            app.UseHangfireDashboard("/hangfire");
            app.UseNancy(x =>
            {
                x.Bootstrapper = new NancyBootstrapper();
                x.PerformPassThrough = context => true;
            });
        }
    }
}
