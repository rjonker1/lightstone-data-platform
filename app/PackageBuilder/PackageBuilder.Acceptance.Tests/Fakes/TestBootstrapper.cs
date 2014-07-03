using Nancy.TinyIoc;
using PackageBuilder.Api;
using PackageBuilder.TestHelper.Mothers;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Acceptance.Tests.Fakes
{
    public class TestBootstrapper : Bootstrapper
    {
        private readonly string _username = string.Empty;
        public TestBootstrapper(string username)
        {
            _username = username;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IAuthenticateUser>(new TestAuthenticator(_username));
            container.Register(PackageLookupMother.GetCannedVersion());
        }
    }
}