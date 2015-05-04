using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EasyNetQ;
using Workflow.BuildingBlocks;

namespace Workflow.Reporting.Consumer.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAdvancedBus>()
                .UsingFactoryMethod(() => BusFactory.CreateAdvancedBus("workflow/reporting/queue"))
                .LifestyleTransient());
        }
    }
}