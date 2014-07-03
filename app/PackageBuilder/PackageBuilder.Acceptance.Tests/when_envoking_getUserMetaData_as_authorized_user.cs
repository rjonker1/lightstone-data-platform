using System.Linq;
using DataPlatform.Shared.Dtos;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Fakes;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests
{
    public class when_envoking_getUserMetaData_as_authorized_user : Specification
    {
        private readonly Browser _browser = new Browser(new TestBootstrapper("admin"));
        private BrowserResponse _response;
        private ApiMetaData _apiMetaData;

        public override void Observe()
        {
            _response = _browser.Get("/getUserMetaData", with =>
            {
                with.HttpRequest();
                with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });

            _apiMetaData = _response.Body.DeserializeJson<ApiMetaData>();
        }

        [Observation]
        public void should_contain_path()
        {
            _apiMetaData.Path.ShouldEqual("/action/{action}");
        }

        [Observation]
        public void should_contain_action()
        {
            _apiMetaData.Actions.First().Name.ShouldEqual("License plate search");
        }

        [Observation]
        public void should_contain_action_criteria()
        {
            var field = _apiMetaData.Actions.First().Criteria.Fields.First();
            field.Name.ShouldEqual("LicenceNo");
            field.Type.ShouldEqual("System.String");
        }
    }
}