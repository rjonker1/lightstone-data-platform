using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Workflow.Publisher.Installers
{
    public class WorkflowInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Setup publisher either WorkflowPublisher using IBus or AdvancedWorkflowPublisher using IAdvancedBus for publishing messages
            //container.Register(Component.For<IWorkflowPublisher>().ImplementedBy<WorkflowPublisher>().LifestyleSingleton());
            container.Register(Component.For<IWorkflowPublisher>().ImplementedBy<AdvancedWorkflowPublisher>().LifestyleSingleton());
        }
    }
}
