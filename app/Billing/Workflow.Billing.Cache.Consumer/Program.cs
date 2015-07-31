using Shared.Configuration;
using Topshelf;

namespace Workflow.Billing.Cache.Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var appSettings = new AppSettings();

            HostFactory.Run(x =>
            {
                x.RunAsPrompt();

                x.Service<IBillingCacheService>(s =>
                {
                    s.ConstructUsing(name => new BillingCacheService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                //x.RunAsLocalSystem();
                x.RunAsPrompt();

                x.SetDescription(appSettings.Service.Description);
                x.SetDisplayName(appSettings.Service.DisplayName);
                x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}