using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private LightstoneAutoDataProvider _consumer;

        public when_consuming_lightstone_data_provider()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new[] {new LicensePlateNumberLightstoneOnlyRequest()};
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
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
            _response.OfType<IProvideDataFromLightstoneAuto>().First().CarId.ShouldEqual(107483);
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_car_year()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Year.ShouldEqual(2008);
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_retail_values()
        {
            var estimatedValue = _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault();
            estimatedValue.RetailConfidenceLevel.Trim().ShouldEqual("Medium");
            estimatedValue.RetailConfidenceValue.Trim().ShouldEqual("60");
            Regex.Replace(estimatedValue.RetailEstimatedHigh, @"\s+", "").ShouldEqual("R96900,00");
            Regex.Replace(estimatedValue.RetailEstimatedLow, @"\s+", "").ShouldEqual("R79300,00");
            Regex.Replace(estimatedValue.RetailEstimatedValue, @"\s+", "").ShouldEqual("R88100,00");
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_trade_values()
        {
            var estimatedValue = _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault();
            estimatedValue.TradeConfidenceLevel.Trim().ShouldEqual("Low");
            estimatedValue.TradeConfidenceValue.Trim().ShouldEqual("50");
            Regex.Replace(estimatedValue.TradeEstimatedHigh, @"\s+", "").ShouldEqual("R86500,00");
            Regex.Replace(estimatedValue.TradeEstimatedLow, @"\s+", "").ShouldEqual("R70800,00");
            Regex.Replace(estimatedValue.TradeEstimatedValue, @"\s+", "").ShouldEqual("R78600,00");
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_cost_values()
        {
            var estimatedValue = _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault();
            Regex.Replace(estimatedValue.CostHigh, @"\s+", "").ShouldEqual("R81300,00");
            Regex.Replace(estimatedValue.CostLow, @"\s+", "").ShouldEqual("R66500,00");
            Regex.Replace(estimatedValue.CostValue, @"\s+", "").ShouldEqual("R73900,00");
        }

        [Observation]
        public void lightstone_response_from_consumer_must_have_correct_auction_values()
        {
            var estimatedValue = _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault();
            Regex.Replace(estimatedValue.AuctionEstimate, @"\s+", "").ShouldEqual("R65200,00");
        }

    }
}
