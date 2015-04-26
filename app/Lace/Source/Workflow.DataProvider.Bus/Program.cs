using Topshelf;
using Workflow.DataProvider.Bus.Consumer;

namespace Workflow.DataProvider.Bus
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<IProcessDataProviderCommands>(s =>
                {
                    s.ConstructUsing(name => new DataProviderCommandProcessor());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription(System.Configuration.ConfigurationManager.AppSettings["service/config/description"]);
                x.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings["service/config/displayName"]);
                x.SetServiceName(System.Configuration.ConfigurationManager.AppSettings["service/config/name"]);
            });
        }
    }
}
