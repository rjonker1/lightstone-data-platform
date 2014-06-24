using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Unit.Tests.Fakes
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

            AutoMapperConfiguration.Init();
            container.Register<IAuthenticateUser>(new TestAuthenticator(_username));
        }
    }
}