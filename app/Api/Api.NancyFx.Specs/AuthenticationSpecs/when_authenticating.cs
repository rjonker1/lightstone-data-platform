using Nancy;
using Nancy.Testing;
using Xunit.Extensions;

namespace Api.NancyFx.Specs.AuthenticationSpecs
{
    public class when_api_key_header_missing : Specification
    {
        private readonly Browser _browser = new Browser(new Bootstrapper());
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Post("/", with =>
            {
                with.HttpRequest();
            });
        }

        [Observation]
        public void should_return_unauthorized()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.Unauthorized);
        }
    }

    public class when_api_key_header_added : Specification
    {
        private readonly Browser _browser = new Browser(new Bootstrapper());
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Post("/", with =>
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
    }
}
