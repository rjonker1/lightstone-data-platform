using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_audatex_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private AudatexDataProvider _consumer;


        public when_consuming_audatex_data_provider()
        {
            _command = MonitoringBusBuilder.ForAudatexCommands(Guid.NewGuid());
            _request = new[] {new LicensePlateNumberAudatexOnlyRequest()};
            _response = new LaceResponseBuilder().WithIvidResponseHandledAndVin12();
        }

        public override void Observe()
        {
            _consumer = new AudatexDataProvider(_request, null, null,_command);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void audatex_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromAudatex>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void audatex_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromAudatex>().First().ShouldNotBeNull();
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
            _response.OfType<IProvideDataFromAudatex>().First().AccidentClaims.Count.ShouldNotEqual(0);
        }
    }
}
