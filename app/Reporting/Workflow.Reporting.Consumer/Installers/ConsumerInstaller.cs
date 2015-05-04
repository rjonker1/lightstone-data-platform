using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Reporting.Consumers.ConsumerTypes;

namespace Workflow.Reporting.Consumer.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ReportConsumer>().ImplementedBy<ReportConsumer>());
        }
    }
}