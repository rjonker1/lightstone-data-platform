using DataPlatform.Shared.Dtos;
using Nancy;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Fakes;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests
{
    public class when_envoking_License_plate_search_as_unauthorized_user : Specification
    {
        private readonly Browser _browser = new Browser(new TestBootstrapper("admin"));
        private BrowserResponse _response;
        private ApiMetaData _apiMetaData;

        public override void Observe()
        {
            _response = _browser.Get(System.Uri.EscapeDataString("/package/License plate search"), with =>
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
}