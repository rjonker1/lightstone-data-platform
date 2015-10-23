using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Domain.Schedules;

namespace Workflow.Billing.Installers
{
    public class ScheduleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICleanup>().ImplementedBy<TransactionRequestCleanup>());
        }
    }
}