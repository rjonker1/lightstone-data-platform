using Hangfire;
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
            app.UseHangfire(config =>
            {
                config.UseSqlServerStorage("Server=.; Database=Hangfire.Test; Integrated Security=SSPI;");
                config.UseServer();
            });

           // new ApiSchedule(userManagementApiClient);
        }
    }
}