using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_lightstone : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_lightstone()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForLightstoneLicensePlate();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _dataProvider = new LightstoneAutoDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_lightstone_response_should_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_response_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_AccidentDistribution_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AccidentDistribution.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_AmortisationFactors_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AmortisationFactors.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_AmortisedValues_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AmortisedValues.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_AreaFactors_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AreaFactors.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_AuctionFactors_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AuctionFactors.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_EstimatedValue_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_Frequency_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.Frequency.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_ImageGauges_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.ImageGauges.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_LastFiveSales_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.LastFiveSales.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_Prices_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.Prices.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_RepairIndex_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.RepairIndex.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_TotalSalesByAge_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.TotalSalesByAge.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_vehicle_valuation_TotalSalesByGender_should_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.TotalSalesByGender.ShouldNotBeNull();
        }
    }
}
