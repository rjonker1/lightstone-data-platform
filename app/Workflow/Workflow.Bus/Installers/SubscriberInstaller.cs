using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Bus.Subscribers;

namespace Workflow.Bus.Installers
{
    public class SubscriberInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Setup publisher either WorkflowSubscriber using IBus or AdvancedWorkflowSubscriber using IAdvancedBus for subscribing to messages
            //container.Register(Component.For<IWorkflowSubscriber>().ImplementedBy<WorkflowSubscriber>());
            container.Register(Component.For<IWorkflowSubscriber>().ImplementedBy<AdvancedWorkflowSubscriber>());
        }
    }
}