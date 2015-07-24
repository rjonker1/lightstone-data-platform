using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumer.Installers
{
    public class CacheProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (ICacheProvider<>)).ImplementedBy(typeof (CacheProvider<>)));
        }
    }
}