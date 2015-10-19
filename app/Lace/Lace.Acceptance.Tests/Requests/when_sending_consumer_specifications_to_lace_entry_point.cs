﻿using System.Collections.Generic;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Requests
{
    public class when_sending_consumer_specifications_to_lace_entry_point : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _responses;
        private readonly IEntryPoint _entryPoint;
        private readonly IAdvancedBus _bus;

        public when_sending_consumer_specifications_to_lace_entry_point()
        {
            _bus = BusFactory.WorkflowBus();
            _request = new ConsumerRequestBuilder().ForSpecifications();
            _entryPoint = new EntryPointService(_bus);
        }

        public override void Observe()
        {
            _responses = _entryPoint.GetResponses(_request);
        }

        [Observation]
        public void lace_request_to_be_loaded_and_responses_to_be_returned_for_all_sources()
        {
            _responses.ShouldNotBeNull();
            _responses.Count.ShouldEqual(13);
            _responses.Count(c => c.Handled).ShouldEqual(1);

            _responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().ShouldNotBeNull();
            _responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().Handled.ShouldBeTrue();
            _responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().ShouldNotBeNull();
            _responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.Count().ShouldEqual(1);
            _responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.First().VehicleDescription.ShouldEqual("Opel Astra 2013");
            _responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.First().DriversName.ShouldEqual("International Panelbeaters");
            //_responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.Count().ShouldEqual(2);
            //_responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.First().VehicleDescription.ShouldEqual("TOYOTA FORTUNER");
            //_responses.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.First().DriversName.ShouldEqual("BB Cars (Pty) Ltd");
        }
    }
}
