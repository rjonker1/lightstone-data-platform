using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_data_provider : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly ICollection<IPointToLaceProvider> _response;
        private LightstoneDataProvider _consumer;

        public when_consuming_lightstone_data_provider()
        {
            _monitoring = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new LicensePlateNumberLightstoneOnlyRequest();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _consumer = new LightstoneDataProvider(_request, null, null,_monitoring);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void lightstone_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
        }
    }
}
