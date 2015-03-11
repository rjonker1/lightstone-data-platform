using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_data_provider : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private IvidDataProvider _consumer;


        public when_consuming_ivid_data_provider()
        {
            _monitoring = MonitoringBusBuilder.ForIvidCommands(Guid.NewGuid());
            _request = new LicensePlateNumberIvidOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new IvidDataProvider(_request, null, null,_monitoring);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void ivid_consumer_must_be_handled()
        {
            _response.IvidResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_response_from_consumer_must_not_be_null()
        {
            _response.IvidResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void ivid_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }
    }
}
