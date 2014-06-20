using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Unit.Tests.Mothers
{
    public class TestBootstrapper : Bootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            AutoMapperConfiguration.Init();
            container.Register<IAuthenticateUser>(new TestAuthenticator());
        }
    }
}