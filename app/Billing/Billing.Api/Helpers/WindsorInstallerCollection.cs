using Billing.Api.Installers;
using Castle.MicroKernel.Registration;
using Shared.BuildingBlocks.Api.Installers;
using Workflow.Billing.Installers;

namespace Billing.Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new NHibernateInstaller(),
            new CacheProviderInstaller(),
            new RepositoryInstaller(),
            new BusInstaller(),
            new AutoMapperInstaller(),
            new UpdateBillingTransactionInstaller(),
            new AuthInstaller(),
            new ApiClientInstaller(),

        };
    }
}