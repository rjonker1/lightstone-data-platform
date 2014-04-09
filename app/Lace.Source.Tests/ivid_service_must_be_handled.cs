using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class ivid_web_service_being_consumed : Specification
    {
        private readonly ILaceRequest _request;
        private ILaceResponse _response;

        public ivid_web_service_being_consumed()
        {
            _request = new LicensePlateNumberIvidOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            var consumer = new IvidConsumer(_request);
            consumer.CallIvidService(_response);
        }

        [Observation]
        public void ivid_web_service_must_be_handled()
        {
            _response.IvidResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_web_service_response_must_not_be_null()
        {
            _response.IvidResponse.ShouldNotBeNull();
        }
    }
}
