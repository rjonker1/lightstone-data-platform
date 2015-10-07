using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;

namespace Workflow.Billing.Installers
{
    public class PublishReportQueueInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IPublishReportQueue<BillingReport>)).ImplementedBy<BillingReport>());
        }
    }
}