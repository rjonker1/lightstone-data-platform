using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shared.Logging;
using Workflow.Publisher;

namespace PackageBuilder.Api.Installers
{
    public class LoggingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Install(FromAssembly.Containing<IWorkflowPublisher>());
            //container.Install(FromAssembly.Containing<IDataPlatformLogger>());
            container.Register(Component.For<IWorkflowPublisher>().ImplementedBy<AdvancedWorkflowPublisher>().LifestyleSingleton());
            container.Register(Component.For<IDataPlatformLogger>().ImplementedBy<DataPlatformLogger>().LifestyleSingleton());
        }
    }
}