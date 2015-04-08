using Api.Domain.Infrastructure.Automapping;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Unit.Tests.Fakes
{
    public class TestBootstrapper : Bootstrapper
    {
        private readonly string _username;

        public TestBootstrapper(string username)
        {
            _username = username;
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            AutoMapperConfiguration.Init();
            container.Register(Component.For<IAuthenticateUser>().Instance(new TestAuthenticator(_username)));
        }
    }
}