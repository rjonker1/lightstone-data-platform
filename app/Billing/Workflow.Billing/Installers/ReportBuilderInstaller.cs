using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;

namespace Workflow.Billing.Installers
{
    public class ReportBuilderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IReportBuilder>().ImplementedBy<ReportBuilder>());
        }
    }
}