using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Workflow.Bus.Installers
{
    public class WorkflowBusServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWorkflowBusService>().ImplementedBy<WorkflowBusService>().LifestyleTransient());
        }
    }
}