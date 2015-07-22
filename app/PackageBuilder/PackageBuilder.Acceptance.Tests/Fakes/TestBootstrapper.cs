using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy.Authentication.Token;
using PackageBuilder.Api;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.Acceptance.Tests.Fakes
{
    public class TestBootstrapper : Bootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(Component.For<ITokenizer>().Instance(new FakeTokenizer()).IsDefault());
        }
    }
}