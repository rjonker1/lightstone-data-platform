using System;
using System.Net.Http.Headers;
using System.Text;
using Lim.Push.Models;
using Lim.Push.RestApi;
using Lim.Test.Helper.Fakes;
using Xunit.Extensions;

namespace Lim.Unit.Tests
{
    public class when_pushing_integration_to_api : Specification
    {
        private readonly string _url = "http://dev.lim.test.api.lightstone.co.za";
        //private readonly string _api = "stockshare/api/stock/importStockItem";
        private readonly string _api = "api/push";

        private readonly string _key = "X-Auth-Token";
        private readonly string _keyValue = "2b1eeb42-0cf7-4234-b798-3bbaa293e273";

        private readonly string _username = "LightStoneAuto";
        private readonly string _password = "49q42FwDSajrF9";

        private readonly HttpPushClient<Transaction, string> _push;

        public when_pushing_integration_to_api()
        {
            _push = new HttpPushClient<Transaction, string>(_url, _api, _key, _keyValue, BuildAuthentication());
        }

        public override void Observe()
        {

        }

        [Observation]
        public void then_push_api_should_get_ok_status_code()
        {
            _push.PostWithNoResponse(FakeTransactions.ForPushApi());
            _push.Dispose();
            _push.IsSuccessful.ShouldBeTrue();
        }

        private AuthenticationHeaderValue BuildAuthentication()
        {
            return new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(_username + ":" + _password)));
        }
    }

    //  "importVehicleRequest": {
  //  "dateTime": "2015-05-12T09:50:23.957",
  //  "user": {
  //    "userName": "Kriswbc@gmail.com",
  //    "uuid": "6a243717-ff1e-4228-ab7d-424422973a03"
  //  },
  //  "vehicle": {
  //    "licenseNumber": "SRX440GP",
  //    "registrationNumber": "FXC352S",
  //    "vinNumber": "AAVZZZ17Z5U021559",
  //    "engineNumber": "BSC199364",
  //    "smartId": "104705",
  //    "segment": "not available",
  //    "manufacturer": "VOLKSWAGEN",
  //    "model": "CitiGolf Chico 1.4 5-dr MY04",
  //    "year": "2005",
  //    "colour": "DARK BLUE",
  //    "licenseExpiryDate": "2015-12-31T00:00:00",
  //    "retailValue": "49900"
  //  },
  //  "stock": {
  //    "verified": "V",
  //    "intoStock": true
  //  }
  //}
}