using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_audatex_data_provider : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private AudatexDataProvider _consumer;


        public when_consuming_audatex_data_provider()
        {
            _monitoring = MonitoringBusBuilder.ForAudatexCommands(Guid.NewGuid());
            _request = new LicensePlateNumberAudatexOnlyRequest();
            _response = new LaceResponseBuilder().WithIvidResponseHandledAndVin12();
        }

        public override void Observe()
        {
            _consumer = new AudatexDataProvider(_request, null, null,_monitoring);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void audatex_consumer_must_be_handled()
        {
            _response.AudatexResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void audatex_response_from_consumer_must_not_be_null()
        {
            _response.AudatexResponse.ShouldNotBeNull();
        }

        [Observation]
        public void audatex_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void audatex_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }

        [Observation]
        public void audatex_consumer_accident_claims_should_not_be_zero()
        {
            _response.AudatexResponse.AccidentClaims.Count.ShouldNotEqual(0);
        }
    }
}
