using Topshelf;

namespace Recoveries.Router
{
    class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(runner =>
            {
                runner.Service<IRecoveryService>(service =>
                {
                    service.ConstructUsing(name => new RecoveryService());
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