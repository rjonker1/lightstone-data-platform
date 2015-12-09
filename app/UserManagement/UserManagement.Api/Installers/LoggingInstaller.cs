using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Shared.Logging;
using Workflow.Publisher;

namespace UserManagement.Api.Installers
{
    public class LoggingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWorkflowPublisher>().ImplementedBy<AdvancedWorkflowPublisher>().LifestyleSingleton());
            container.Install(FromAssembly.Containing<IDataPlatformLogger>());
        }
    }
}