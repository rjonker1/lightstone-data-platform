using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Common.Logging;
using Topshelf;
using Workflow.Publisher.Configurations;

namespace Workflow.Bus
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        public static void Main(string[] args)
        {
            //var container = new WindsorContainer().Install(FromAssembly.InThisApplication());
            var container = new WindsorContainer().Install(FromAssembly.InDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory)));
            
            HostFactory.Run(x =>
            {
                x.Service<IWorkflowBusService>(s =>
                {
                    s.ConstructUsing(name => container.Resolve<IWorkflowBusService>());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc =>
                    {
                        Log.InfoFormat("Cleaning up after shutdown");
                        tc.Stop();

                        Log.InfoFormat("Releasing container");
                        container.Release(tc);
                        container.Dispose();
                        container = null;

                        Log.InfoFormat("Container released");
                    });
                });

                x.RunAsLocalSystem();

                x.SetDescription(ConfigurationReader.Bus.ServiceDescription);
                x.SetDisplayName(ConfigurationReader.Bus.DisplayName);
                x.SetServiceName(ConfigurationReader.Bus.ServiceName);
            });
        }
    }
}