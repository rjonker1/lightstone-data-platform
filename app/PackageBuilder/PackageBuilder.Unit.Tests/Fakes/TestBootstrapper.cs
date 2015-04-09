using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PackageBuilder.Api;
using Shared.BuildingBlocks.Api.Security;
using Shared.Public.TestHelpers.Security;

namespace PackageBuilder.Unit.Tests.Fakes
{
    public class TestBootstrapper : Bootstrapper
    {
        private readonly string _username = string.Empty;
        public TestBootstrapper(string username)
        {
            _username = username;
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(Component.For<IAuthenticateUser>().Instance(new TestAuthenticator(_username)));
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion()));
        }
    }
}