using Castle.Windsor;
using UserManagement.Api.Helpers;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.TestHelper.BaseTests
{
    public abstract class BaseTestHelper : Specification
    {
        public IWindsorContainer Container = new WindsorContainer();

        protected BaseTestHelper()
        {
            // NB: When running multiple unit tests, all dependencies are required as some static classes such as AutoMapper selects any random Windsor Container to resolve its dependencies,
            // and based on the specific test that created that particular Windsor Container with it's specific dependencies may not be the Container used by AutoMapper for that particular test.
            Container.Install(WindsorInstallerCollection.Installers);

            OverrideHelper.OverrideNhibernateCfg(Container);
        }
    }
}