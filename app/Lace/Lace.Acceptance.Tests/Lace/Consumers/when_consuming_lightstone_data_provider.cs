using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_data_provider : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendCommandsToBus _monitoring;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private LightstoneDataProvider _consumer;

        public when_consuming_lightstone_data_provider()
        {
            _monitoring = BusBuilder.ForIvidCommands(Guid.NewGuid());
            _request = new LicensePlateNumberLightstoneOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new LightstoneDataProvider(_request, null, null,_monitoring);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void lightstone_consumer_must_be_handled()
        {
            _response.LightstoneResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_null()
        {
            _response.LightstoneResponse.ShouldNotBeNull();
        }
    }
}
