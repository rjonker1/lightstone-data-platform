using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Publisher;

namespace Workflow.Bus.Installers
{
    public class WorkflowInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWorkflowBus>().ImplementedBy<WorkflowBus>().LifestyleTransient());
            container.Register(Component.For<IWorkflowBusService>().ImplementedBy<WorkflowBusService>().LifestyleTransient());
        }
    }
}