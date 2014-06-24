using System.Linq;
using DataPlatform.Shared.Dtos;
using Nancy.Testing;
using PackageBuilder.Unit.Tests.Fakes;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests
{
    public class when_envoking_action_authorized : Specification
    {
        private readonly Browser _browser = new Browser(new TestBootstrapper("admin"));
        private BrowserResponse _response;
        private Package _package;

        public override void Observe()
        {
            _response = _browser.Get(System.Uri.EscapeDataString("/package/License plate search"), with =>
            {
                with.HttpRequest();
                with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });

            _package = _response.Body.DeserializeJson<Package>();
        }

        [Observation]
        public void should_contain_action_name()
        {
            _package.Action.Name.ShouldEqual("License plate search");
        }

        [Observation]
        public void should_contain_datasets()
        {
            _package.DataSets.Count().ShouldEqual(3);
            _package.DataSets.ElementAt(0).Name.ShouldEqual("Vehicle verification");
            _package.DataSets.ElementAt(1).Name.ShouldEqual("Repair history");
            _package.DataSets.ElementAt(2).Name.ShouldEqual("Values");
        }

        [Observation]
        public void should_contain_datafields()
        {
            var dataField = _package.DataSets.First().DataFields.First();
            dataField.Name.ShouldEqual("Colour");
            dataField.Type.ShouldEqual("System.String");
        }
    }
}