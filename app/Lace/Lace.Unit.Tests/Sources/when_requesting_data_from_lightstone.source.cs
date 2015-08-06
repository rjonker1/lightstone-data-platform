using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_lightstone_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromSource;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly ICallTheDataProviderSource _callTheSource;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public when_requesting_data_from_lightstone_source()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _requestDataFromSource = new RequestDataFromLightstoneAuto();
            // _request = new LicensePlateRequestBuilder().ForLightstoneLicensePlate();
            _request = new LicensePlateRequestBuilder().ForLightstoneVinNumber();
            // _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _response = new Collection<IPointToLaceProvider>();

            _dataProvider = _request.GetFromRequest<IPointToLaceRequest>()
                .Package.DataProviders.Single(w => w.Name == DataProviderName.LightstoneAuto);
            _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LightstoneAuto, _dataProvider);

            _callTheSource = new CallLightstoneAutoDataProvider(_dataProvider, new FakeDataProviderRepository(), _logCommand);
        }

        public override void Observe()
        {
            _requestDataFromSource.FetchDataFromSource(_response, _callTheSource);
        }

        [Observation]
        public void lace_lightstone_response_data_from_service_response_must_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_data_from_service_must_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_response_car_full_name_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().CarFullname.ShouldEqual("TOYOTA Auris 1.6 RT 5-dr");
        }

        [Observation]
        public void lace_lightstone_response_carid_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().CarId.ShouldEqual(107483);
        }

        [Observation]
        public void lace_lightstone_response_image_url_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ImageUrl.ShouldEqual("http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg");
        }

        [Observation]
        public void lace_lighstone_response_model_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Model.ShouldEqual("Auris 1.6 RT 5-dr");
        }


        [Observation]
        public void lace_lighstone_response_quarter_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Quarter.ShouldEqual("3rd Quarter");
        }

        //[Observation]
        //public void lace_lighstone_response_vehicleValuation_accident_distribution_count_must_be_correct()
        //{
        //    _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AccidentDistribution.Count().ShouldEqual(3);
        //}


        [Observation]
        public void lace_lighstone_response_vehicleValuation_amortised_values_count_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>()
                .First()
                .VehicleValuation.AmortisedValues.Count()
                .ShouldEqual(4);
        }


        //[Observation]
        //public void lace_lighstone_response_vehicleValuation_area_factors_count_must_be_correct()
        //{
        //    _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.AreaFactors.Count().ShouldEqual(121);
        //}


        [Observation]
        public void lace_lighstone_response_vehicleValuation_retail_estimated_value_confidence_level_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .RetailConfidenceLevel.ShouldEqual("Medium");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_retail_estimated_value_estimated_high_must_be_correct()
        {
            Regex.Replace(_response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .RetailEstimatedHigh, @"\s+", "").ShouldEqual("R96900,00");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_retail_estimated_value_estimated_low_must_be_correct()
        {
            Regex.Replace(_response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .RetailEstimatedLow, @"\s+", "").ShouldEqual("R79300,00");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_trade_estimated_value_confidence_level_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .RetailConfidenceLevel.ShouldEqual("Medium");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_trade_estimated_value_estimated_high_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .TradeEstimatedHigh.Trim().ShouldEqual(86500.ToString("C"));
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_trade_estimated_value_estimated_low_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .TradeEstimatedLow.ShouldEqual(70800.ToString("C"));
        }


        [Observation]
        public void lace_lighstone_response_vehicleValuation_retail_estimated_value_estimated_value_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.EstimatedValue.FirstOrDefault()
                .TradeEstimatedValue.Trim().ShouldEqual(78600.ToString("C"));
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_image_gauges_count_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.ImageGauges.Count().ShouldEqual(6);
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_last_five_sales_count_must_be_correct()
        {
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.LastFiveSales.Count().ShouldEqual(5);
        }

        //[Observation]
        //public void lace_lighstone_response_vehicleValuation_repair_index_count_must_be_correct()
        //{
        //    _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.RepairIndex.Count().ShouldEqual(9);
        //}
    }
}
