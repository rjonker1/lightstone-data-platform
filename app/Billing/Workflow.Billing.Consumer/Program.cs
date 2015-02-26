using Shared.Configuration;
using Topshelf;

namespace Workflow.Billing.Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var appSettings = new AppSettings();


            HostFactory.Run(x =>
            {
                x.Service<IBillingService>(s =>
                {
                    s.ConstructUsing(name => new BillingService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription(appSettings.Service.Description);
                x.SetDisplayName(appSettings.Service.DisplayName);
                x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}