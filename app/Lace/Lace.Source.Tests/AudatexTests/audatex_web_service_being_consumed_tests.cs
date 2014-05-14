using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests.AudatexTests
{
    public class audatex_web_service_being_consumed_tests : Specification
    {

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILaceResponse _response;

        public audatex_web_service_being_consumed_tests()
        {
            _request = new LicensePlateNumberAudatexOnlyRequest();
            _response = new LaceResponse();
        }


        public override void Observe()
        {
            var consumer = new AudatexConsumer(_request);
            consumer.CallAudatexService(_response, _laceEvent);
        }

        [Observation]
        public void audatex_web_service_must_be_handled()
        {
            _response.AudatexResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void audatex_web_service_response_must_not_be_null()
        {
            _response.AudatexResponse.ShouldNotBeNull();
        }
    }
}
