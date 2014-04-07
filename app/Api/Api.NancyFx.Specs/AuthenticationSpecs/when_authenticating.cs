using Nancy;
using Nancy.Testing;
using Xunit.Extensions;

namespace Api.NancyFx.Specs.AuthenticationSpecs
{
    public class when_api_key_header_missing : Specification
    {
        private Browser _browser = new Browser(new AuthenticationBootstrapper());
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Get("/", with =>
            {
                with.HttpRequest();
            });
        }

        [Observation]
        public void should_debit_the_from_account_by_the_amount_transferred()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.Unauthorized);
        }
    }

    public class when_api_key_header_added : Specification
    {
        private Browser _browser = new Browser(new AuthenticationBootstrapper());
        private BrowserResponse _response;

        public override void Observe()
        {
            _response = _browser.Get("/requiresAuthentication", with =>
            {
                with.HttpRequest();
                with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });
        }

        [Observation]
        public void should_debit_the_from_account_by_the_amount_transferred()
        {
            _response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }
    }
}
