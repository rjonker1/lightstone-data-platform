using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Publisher;

namespace UserManagement.Api.Installers
{
    public class WorkflowInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWorkflowBus>().ImplementedBy<WorkflowBus>().LifestyleTransient());
        }
    }
}