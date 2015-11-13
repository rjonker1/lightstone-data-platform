using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests.ConsumerRequests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.LsConsumer
{
    public class when_consuming_ls_consumer_specifications_web_service :Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private ConsumerSpecificationsDataProvider _consumer;

        public when_consuming_ls_consumer_specifications_web_service()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new[] { new SpecificationsRequest() };
            _response = new Collection<IPointToLaceProvider>(); ;
        }

        public override void Observe()
        {
            _consumer = new ConsumerSpecificationsDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void lightstone_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_empty()
        {
            _response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.Count().ShouldEqual(1);
            _response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.First().VehicleDescription.ShouldEqual("Opel Astra 2013");
            _response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First().RepairData.First().DriversName.ShouldEqual("International Panelbeaters");
        }
    }
}
