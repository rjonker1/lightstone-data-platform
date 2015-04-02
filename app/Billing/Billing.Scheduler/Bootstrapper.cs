using System;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Billing.Scheduler.Bootstrapper))]

namespace Billing.Scheduler
{
    public class Bootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfire(config =>
            {
                config.UseSqlServerStorage("Server=.; Database=Hangfire.Test; Integrated Security=SSPI;");
                config.UseServer();
            });

            RecurringJob.AddOrUpdate(() => Console.Write("Integrity Testeroonie"), "*/5 * * * *");
        }
    }
}