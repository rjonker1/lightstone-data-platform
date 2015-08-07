using Castle.Windsor;
using Castle.Windsor.Installer;
using Topshelf;

namespace Recoveries.Router
{
    class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            HostFactory.Run(runner =>
            {
                runner.Service<IRecoveryService>(service =>
                {
                    service.ConstructUsing(name => container.Resolve<IRecoveryService>());
                    service.WhenStarted(tc => tc.Start());
                    service.WhenStopped(tc => tc.Stop());
                });

                runner.RunAs(System.Configuration.ConfigurationManager.AppSettings["service/config/username"],
                    System.Configuration.ConfigurationManager.AppSettings["service/config/password"]);
                runner.SetDescription(System.Configuration.ConfigurationManager.AppSettings["service/config/description"]);
                runner.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings["service/config/displayName"]);
                runner.SetServiceName(System.Configuration.ConfigurationManager.AppSettings["service/config/name"]);
            });
        }
    }
}