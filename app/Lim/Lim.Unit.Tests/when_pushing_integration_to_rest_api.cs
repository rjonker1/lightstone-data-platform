using System.Linq;
using Lim.Test.Api.Modules;
using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Extensions;

namespace Lim.Unit.Tests
{
    public class when_pushing_integration_to_rest_api : Specification
    {
       // private readonly DefaultNancyBootstrapper _bootstrapper;
       // private readonly Browser _browser;

        public when_pushing_integration_to_rest_api()
        {
          //  _bootstrapper = new DefaultNancyBootstrapper();
           var  _browser = new Browser(with => with.Module<FakeDealerPullApi>());
        }

        public override void Observe()
        {

        }

        [Observation]
        public void then_you_should_get_a_valid_response_from_fake_api_with_dealers_request()
        {
            //var result = _browser.Get("/api/get/dealerships", with =>
            //{
            //    with.HttpRequest();
            //    with.Header("Accept", "application/json");
            //});

            //result.StatusCode.ShouldEqual(HttpStatusCode.OK);
            //var json = result.Body.AsString();

            //var obj = (JArray) JsonConvert.DeserializeObject(json);
            //obj.Count().ShouldEqual(1);
        }
    }
}