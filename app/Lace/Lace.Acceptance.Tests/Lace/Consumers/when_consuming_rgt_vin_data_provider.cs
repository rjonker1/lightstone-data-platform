using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_rgt_vin_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private RgtVinDataProvider _consumer;


        public when_consuming_rgt_vin_data_provider()
        {
            _command = MonitoringBusBuilder.ForRgtVinCommands(Guid.NewGuid());
            _request = new[] {new LicensePlateNumberRgtVinOnlyRequest()};
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _consumer = new RgtVinDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void rgt_vin_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void rgt_vin_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void rgt_vin_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }
    }
}
