using Lace.Events;
using Lace.Events.Messages;
using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin;
using Lace.Source.Tests.Data;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.RgtVinTests
{
    public class rgt_vin_service_being_consumed_tests : Specification
    {

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private ILaceResponse _response;


        public rgt_vin_service_being_consumed_tests()
        {
            _laceEvent = new PublishEvent(new FakeBus());
            _request = new LicensePlateNumberRgtVinOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            var consumer = new RgtVinConsumer(_request);
            consumer.CallRgtVinService(_response, _laceEvent);
        }

        [Observation]
        public void rgt_vin_web_service_must_be_handled_test()
        {
            _response.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void rgt_vin_web_service_response_must_not_be_null_test()
        {
            _response.RgtVinResponse.ShouldNotBeNull();
        }

    }
}
