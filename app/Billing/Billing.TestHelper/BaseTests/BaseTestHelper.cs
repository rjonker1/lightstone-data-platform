using Billing.TestHelper.Helpers;
using Castle.Windsor;
using Workflow.Billing.Consumers.Installers;
using Workflow.Billing.Installers;
using Xunit.Extensions;

namespace Billing.TestHelper.BaseTests
{
    public abstract class BaseTestHelper : Specification
    {
        public IWindsorContainer Container = new WindsorContainer();

        protected BaseTestHelper()
        {
            // NB: When running multiple unit tests, all dependencies are required as some static classes such as AutoMapper selects any random Windsor Container to resolve its dependencies,
            // and based on the specific test that created that particular Windsor Container with it's specific dependencies may not be the Container used by AutoMapper for that particular test.
            Container.Install(
                new NHibernateInstaller(),
                new WindsorInstaller(),
                new CacheProviderInstaller(),
                new RepositoryInstaller(),
                new AutoMapperInstaller(),
                new ConsumerInstaller(),
                new BusInstaller(),
                new PublishReportQueueInstaller(),
                new PivotInstaller());

            //OverrideHelper.OverrideNhibernateCfg(Container);
        }
    }
}