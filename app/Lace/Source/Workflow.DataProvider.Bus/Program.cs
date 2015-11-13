using Lace.Domain.DataProviders.Core.Configuration;
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
                x.Service<IDataProviderWorker>(s =>
                {
                    s.ConstructUsing(name => new DataProviderWorker());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription(WorkflowConfiguration.ServiceDescription);
                x.SetDisplayName(WorkflowConfiguration.ServiceDisplayName);
                x.SetServiceName(WorkflowConfiguration.ServiceName);
            });
        }
    }
}
