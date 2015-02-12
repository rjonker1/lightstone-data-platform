using Api.Domain.Verification.Infrastructure.Dto;
using Api.Tests.Helper.Builder;
using Api.Unit.Tests.Fakes;
using Nancy;
using Nancy.Testing;
using Xunit.Extensions;

namespace Api.Unit.Tests
{
    public class when_sending_drivers_license_request : Specification
    {
        //private readonly DefaultNancyBootstrapper _bootstrapper;
        private readonly Browser _browser;
        private BrowserResponse _result;
        private readonly DriversLicenseRequestDto _request;

        public when_sending_drivers_license_request()
        {
            //_bootstrapper = new TestBootstrapper("user");
            _browser = new Browser(new TestBootstrapper("user"));
            _request = DriversLicenseScanBuilder.ForDriversLicenseRequest();
        }

        public override void Observe()
        {
        }

        [Observation]
        public void then_drivers_verifcation_should_return_ok_when_route_exists()
        {
            _result = _browser.Get("/api/verification/driversLicense");
            _result.StatusCode.ShouldEqual(HttpStatusCode.OK);
            //_result.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }


        [Observation]
        public void then_drivers_verifcation_should_return_a_valid_result()
        {
            _result = _browser.Post("/api/verification/driversLicense", with =>
            {
                with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
                with.Header("Accept", "application/json");
                with.Query("packageId", "EB49A837-D9E3-4F2A-8DC9-2CB0BB5D48E2");
                with.Query("packageVersion", "1");
                with.JsonBody(_request);
            });
            _result.ShouldNotBeNull();
        }
    }


   
}
