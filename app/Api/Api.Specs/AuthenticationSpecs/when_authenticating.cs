using Nancy;
using Nancy.Security;
using Nancy.Testing;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;
using Xunit.Extensions;

namespace Api.Specs.AuthenticationSpecs
{
    public class when_api_key_header_missing : Specification
    {
        class FakeAuthenticator : IAuthenticateUser
        {
            public IUserIdentity GetUserIdentity(string token)
            {
                return new ApiUser("testUser");
            }
        }
        class NancyBootstrapper : Bootstrapper
        {
            protected override void ConfigureApplicationContainer(TinyIoCContainer container)
            {
                AutoMapperConfiguration.Init();
                container.Register<IAuthenticateUser>(new FakeAuthenticator());
            }
        }

        private readonly Browser _browser = new Browser(new NancyBootstrapper());
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Post("/license", with => with.HttpRequest());
        }

        [Observation]
        public void should_return_unauthorized()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.Unauthorized);
        }
    }

    public class when_api_key_header_added : Specification
    {
        class FakeAuthenticator : IAuthenticateUser
        {
            public IUserIdentity GetUserIdentity(string token)
            {
                return new ApiUser("testUser");
            }
        }
        class NancyBootstrapper : Bootstrapper
        {
            protected override void ConfigureApplicationContainer(TinyIoCContainer container)
            {
                AutoMapperConfiguration.Init();
                container.Register<IAuthenticateUser>(new FakeAuthenticator());
            }
        }

        private readonly Browser _browser = new Browser(new NancyBootstrapper());
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Post("/license", with =>
            {
                with.HttpRequest();
                with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });
        }

        [Observation]
        public void should_return_ok()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }

        [Observation]
        public void should_return_json_authenticated_text()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }
    }
}
