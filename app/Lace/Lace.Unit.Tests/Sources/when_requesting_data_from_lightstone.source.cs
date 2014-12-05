using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_lightstone_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromSource;
        private readonly ILaceRequest _request;
        private IProvideResponseFromLaceDataProviders _response;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly ICallTheDataProviderSource _callTheSource;

        public when_requesting_data_from_lightstone_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _requestDataFromSource = new RequestDataFromLightstoneSource();
            _request = new LicensePlateRequestBuilder().ForLightstone();
            _response = new LaceResponse();
            _callTheSource = new CallLightstoneDataProvider(_request, new FakeRepositoryFactory(), new FakeCarRepositioryFactory());
           // _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
        }

        public override void Observe()
        {
            _requestDataFromSource.FetchDataFromSource(_response, _callTheSource, _laceEvent);
        }

        [Observation]
        public void lace_lightstone_response_data_from_service_response_must_not_be_null()
        {
            _response.LightstoneResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_response_data_from_service_must_be_handled()
        {
            _response.LightstoneResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_lightstone_response_car_full_name_must_be_correct()
        {
            _response.LightstoneResponse.CarFullname.ShouldEqual("TOYOTA Auris 1.6 RT 5-dr");
        }

        [Observation]
        public void lace_lightstone_response_carid_must_be_correct()
        {
            _response.LightstoneResponse.CarId.ShouldEqual(107483);
        }

        [Observation]
        public void lace_lightstone_response_image_url_must_be_correct()
        {
            _response.LightstoneResponse.ImageUrl.ShouldEqual("http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg");
        }

        [Observation]
        public void lace_lighstone_response_model_must_be_correct()
        {
            _response.LightstoneResponse.Model.ShouldEqual("Auris 1.6 RT 5-dr");
        }


        [Observation]
        public void lace_lighstone_response_quarter_must_be_correct()
        {
            _response.LightstoneResponse.Quarter.ShouldEqual("3rd Quarter");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_accident_distribution_count_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.AccidentDistribution.Count().ShouldEqual(3);
        }


        [Observation]
        public void lace_lighstone_response_vehicleValuation_amortised_values_count_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.AmortisedValues.Count().ShouldEqual(4);
        }


        [Observation]
        public void lace_lighstone_response_vehicleValuation_area_factors_count_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.AreaFactors.Count().ShouldEqual(104);
        }


        [Observation]
        public void lace_lighstone_response_vehicleValuation_estimated_value_confidence_level_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.EstimatedValue.FirstOrDefault()
                .ConfidenceLevel.ShouldEqual("Medium");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_estimated_value_estimated_high_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.EstimatedValue.FirstOrDefault()
                .EstimatedHigh.ShouldEqual("R 98 700,00");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_estimated_value_estimated_low_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.EstimatedValue.FirstOrDefault()
                .EstimatedLow.ShouldEqual("R 80 600,00");
        }


        [Observation]
        public void lace_lighstone_response_vehicleValuation_estimated_value_estimated_value_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.EstimatedValue.FirstOrDefault()
                .EstimatedValue.ShouldEqual("R 89 200,00");
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_image_gauges_count_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.ImageGauges.Count().ShouldEqual(5);
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_last_five_sales_count_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.LastFiveSales.Count().ShouldEqual(5);
        }

        [Observation]
        public void lace_lighstone_response_vehicleValuation_repair_index_count_must_be_correct()
        {
            _response.LightstoneResponse.VehicleValuation.RepairIndex.Count().ShouldEqual(9);
        }
    }
}
