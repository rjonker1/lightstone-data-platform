using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_data_provider_with_car_id : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private LightstoneAutoDataProvider _consumer;

        public when_consuming_lightstone_data_provider_with_car_id()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new[] {new CarIdLightstoneOnlyRequest()};
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _consumer = new LightstoneAutoDataProvider(_request, null, null,_command);
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

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_car_id()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().CarId.ShouldEqual(111684);
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_car_year()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Year.ShouldEqual(2013);
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_retail_values()
        {
            var estimatedValue = _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault();
            Regex.Replace(estimatedValue.RetailConfidenceLevel, @"\s+", "").ShouldEqual("Medium");
            Regex.Replace(estimatedValue.RetailConfidenceValue, @"\s+", "").ShouldEqual("74");
            Regex.Replace(estimatedValue.RetailEstimatedHigh, @"\s+", "").ShouldEqual("R549200,00");
            Regex.Replace(estimatedValue.RetailEstimatedLow, @"\s+", "").ShouldEqual("R459000,00");
            Regex.Replace(estimatedValue.RetailEstimatedValue, @"\s+", "").ShouldEqual("R502100,00");
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_trade_values()
        {
            var estimatedValue = _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault();
            estimatedValue.TradeConfidenceLevel.ShouldEqual("Low");
            estimatedValue.TradeConfidenceValue.ShouldEqual("50");
            Regex.Replace(estimatedValue.TradeEstimatedHigh, @"\s+", "").ShouldEqual("R488200,00");
            Regex.Replace(estimatedValue.TradeEstimatedLow, @"\s+", "").ShouldEqual("R408000,00");
            Regex.Replace(estimatedValue.TradeEstimatedValue, @"\s+", "").ShouldEqual("R446300,00");
        }
    }
}
