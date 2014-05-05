using Nancy.Security;
using Nancy.Testing;
using Shared.BuildingBlocks.Api.Security;
using UmApi;
using UmApi.Modules;
using Xunit.Extensions;

namespace CasApi.NancyFx.Specs.AuthenticationSpecs
{
    public class when_api_key_header_missing : Specification
    {
        class FakeAuthenticator : IAuthenticateUser
        {
            public IUserIdentity GetUserIdentity(string token)
            {
                return null;
            }
        }

        private readonly Browser _browser = new Browser(cfg =>
        {
            cfg.Module<AuthModule>();
            var fakeAuthenticator = new FakeAuthenticator();
            cfg.Dependency<IAuthenticateUser>(fakeAuthenticator);
        });
        private BrowserResponse _response;
        public override void Observe()
        {
            _response = _browser.Post("/authenticate", with =>
            {
                with.HttpRequest();
            });
        }

        [Observation]
        public void should_return_null()
        {
            _response.Body.AsString().ShouldEqual("null");
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

        private readonly Browser _browser = new Browser(cfg =>
        {
            cfg.Module<AuthModule>();
            var fakeAuthenticator = new FakeAuthenticator();
            cfg.Dependency<IAuthenticateUser>(fakeAuthenticator);
        });
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Post("/authenticate", with =>
            {
                with.HttpRequest();
                with.Header("Authorization", "ApiKey fakeKey");
            });
        }

        [Observation]
        public void should_return_user_identity()
        {
            _response.Body.AsString().ShouldContain("testUser");
        }
    }
}
