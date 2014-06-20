using Nancy.Security;
using Nancy.Testing;
using Shared.BuildingBlocks.Api.Security;
using UmApi.Modules;
using Xunit.Extensions;

namespace UmApi.Unit.Tests
{
    public class when_api_key_header_missing : Specification
    {
        class TestAuthenticator : IAuthenticateUser
        {
            public IUserIdentity GetUserIdentity(string token)
            {
                return null;
            }
        }

        private readonly Browser _browser = new Browser(cfg =>
        {
            cfg.Module<AuthModule>();
            var fakeAuthenticator = new TestAuthenticator();
            cfg.Dependency<IAuthenticateUser>(fakeAuthenticator);
        });

        private BrowserResponse _response;
        public override void Observe()
        {
            _response = _browser.Post("/authenticate", with => with.HttpRequest());
        }

        [Observation]
        public void should_return_null()
        {
            _response.Body.AsString().ShouldEqual("null");
        }
    }
}