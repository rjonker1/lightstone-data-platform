using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers;

namespace Workflow.Billing.Consumer.Installers
{
    public class PivotInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IPivotBilling<PivotStageBilling>)).ImplementedBy<PivotStageBilling>().LifestyleTransient());
            container.Register(Component.For(typeof(IPivotBilling<PivotFinalBilling>)).ImplementedBy<PivotFinalBilling>().LifestyleTransient());
        }
    }
}