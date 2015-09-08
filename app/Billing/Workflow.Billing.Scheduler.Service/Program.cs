using System.Configuration;
using Hangfire;
using Hangfire.Logging.LogProviders;
using Shared.Configuration;
using Topshelf;

namespace Workflow.Billing.Scheduler.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //var appSettings = new AppSettings();

            GlobalConfiguration.Configuration
            .UseLogProvider(new ColouredConsoleLogProvider())
            .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["billingScheduler"].ConnectionString);

            HostFactory.Run(x =>
            {
                x.RunAsPrompt();

                x.Service<IBillingSchedulerService>(s =>
                {
                    s.ConstructUsing(name => new BillingSchedulerService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                //x.RunAsLocalSystem();
                x.RunAsPrompt();

                //x.SetDescription(appSettings.Service.Description);
                //x.SetDisplayName(appSettings.Service.DisplayName);
                //x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}
