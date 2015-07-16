using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_lighstone_response : Specification
    {
        private IProvideDataFromLightstoneAuto _response;
        private TransformLightstoneResponse _transform;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IHaveCarInformation _carInformationRequest;
        private readonly IRetrieveValuationFromMetrics _retrieveValuationFromMetrics;
        private readonly IRetrieveCarInformation _retrieveCarInformation;
        
        public when_transforming_lighstone_response()
        {
            _request = new[] {new LicensePlateNumberLightstoneOnlyRequest()};
            _carInformationRequest = LaceRequestCarInformationRequestBuilder.ForCarId_107483_ButNoVin();
            _retrieveValuationFromMetrics =
                LighstoneVehicleInformationBuilder.ForValuationFromMetrics(_carInformationRequest);
            _retrieveCarInformation = LighstoneVehicleInformationBuilder.ForCarInformation("SB1KV58E40F039277");
        }

        public override void Observe()
        {
            _transform = new TransformLightstoneResponse(_retrieveValuationFromMetrics, _retrieveCarInformation);
            _transform.Transform();
            _response = _transform.Result;
        }

        [Observation]
        public void lightstone_transformer_continue_with_transformation_must_be_true()
        {
            _transform.Continue.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_transformer_result_should_not_be_null()
        {
            _transform.Result.ShouldNotBeNull();
        }

        [Observation]
        public void lightstone_transformer_must_have_valuation_information()
        {
            _transform.Result.VehicleValuation.ShouldNotBeNull();
        }

        //[Observation]
        //public void lighstone_transformer_vechicle_valuation_must_have_accident_distribution()
        //{
        //    _transform.Result.VehicleValuation.AccidentDistribution.Count().ShouldEqual(3);
        //}

        [Observation]
        public void lighstone_transformer_vechicle_valuation_must_have_amortised_values()
        {
            _transform.Result.VehicleValuation.AmortisedValues.Count().ShouldEqual(4);
        }

        //[Observation]
        //public void lighstone_transformer_vechicle_valuation_must_have_area_factors()
        //{
        //    _transform.Result.VehicleValuation.AreaFactors.Count().ShouldEqual(121);
        //}

        [Observation]
        public void lighstone_transformer_vechicle_valuation_must_have_estimated_value()
        {
            _transform.Result.VehicleValuation.EstimatedValue.Count().ShouldEqual(1);
        }

        [Observation]
        public void lighstone_transformer_vechicle_valuation_must_have_image_gauges()
        {
            _transform.Result.VehicleValuation.ImageGauges.Count().ShouldEqual(6);
        }

        [Observation]
        public void lighstone_transformer_vehicle_valuation_must_have_last_five_sales()
        {
            _transform.Result.VehicleValuation.LastFiveSales.Count().ShouldEqual(5);
        }

        //[Observation]
        //public void lighstone_transformer_vechicle_valuation_must_have_repair_index()
        //{
        //    _transform.Result.VehicleValuation.RepairIndex.Count().ShouldEqual(9);
        //}

        [Observation]
        public void lightstone_transformer_must_have_car_information()
        {
            _transform.Result.CarId.ShouldEqual(107483);
        }
    }
}
