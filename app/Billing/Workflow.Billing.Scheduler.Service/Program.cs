using System.Configuration;
using Hangfire;
using Hangfire.Logging.LogProviders;
using Shared.Configuration;
using Topshelf;

namespace Workflow.Billing.Scheduler.Service
{
    class Program
    {
        private BackgroundJobServer _server;

        static void Main(string[] args)
        {
            var appSettings = new AppSettings();

            HostFactory.Run(x =>
            {
                x.RunAsPrompt();

                x.Service<IBillingSchedulerService>(s =>
                {
                    s.ConstructUsing(name => new BillingSchedulerService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsPrompt();

                x.SetDescription(appSettings.Service.Description);
                x.SetDisplayName(appSettings.Service.DisplayName);
                x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}
