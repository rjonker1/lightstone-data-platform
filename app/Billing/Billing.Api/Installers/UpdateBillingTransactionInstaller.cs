using Billing.Domain.Entities;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Billing.Api.Installers
{
    public class UpdateBillingTransactionInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<UpdateBillingTransaction>().ImplementedBy<UpdateBillingTransaction>());
        }
    }
}