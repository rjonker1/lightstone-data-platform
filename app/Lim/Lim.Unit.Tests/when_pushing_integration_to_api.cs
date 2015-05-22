using Lim.Push.RestApi;
using Lim.Test.Helper.Fakes;
using Xunit.Extensions;

namespace Lim.Unit.Tests
{
    public class when_pushing_integration_to_api : Specification
    {
        private readonly string _url = "http://dev.lim.test.api.lightstone.co.za";
        private readonly string _api = "api/push";

        private readonly string _key = "X-Auth-Token";
        private readonly string _keyValue = "2b1eeb42-0cf7-4234-b798-3bbaa293e273";

        private readonly string _username = "LightStoneAuto";
        private readonly string _password = "49q42FwDSajrF9";
        private readonly PushClient _push; 

        public when_pushing_integration_to_api()
        {
            _push = PushClient.PushWithBasic(_url, _api, _key, _keyValue, _username, _password);
            
        }

        public override void Observe()
        {

        }

        [Observation]
        public void then_push_api_should_get_ok_status_code()
        {
            _push.Post(FakeTransactions.ForPushApi());
            _push.IsSuccessful.ShouldBeTrue();
            _push.Dispose();
        }
    }
}