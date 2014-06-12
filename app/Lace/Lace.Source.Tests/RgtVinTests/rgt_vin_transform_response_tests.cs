using System.Data;
using Lace.Source.RgtVin.Transform;
using Lace.Source.Tests.Data.RgtVin;
using Xunit.Extensions;

namespace Lace.Source.Tests.RgtVinTests
{
    public class rgt_vin_transform_response_tests : Specification
    {

        private readonly DataSet _rgtVinWebResponse;
        private TransformRgtVinResponse _transfomer;


        public rgt_vin_transform_response_tests()
        {
            _rgtVinWebResponse = MockRgtVinResponseData.GetRgtVinWebResponseForLicensePlateNumber();
        }


        public override void Observe()
        {
            _transfomer = new TransformRgtVinResponse(_rgtVinWebResponse);
            _transfomer.Transform();
        }

        [Observation]
        public void rgt_vin_transformer_continue_with_transformation_must_be_true_test()
        {
            _transfomer.Continue.ShouldBeTrue();
        }


        [Observation]
        public void rgt_vin_transformer_result_should_not_be_null_test()
        {
            _transfomer.Result.ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_transformer_result_color_should_be_valid_test()
        {
            _transfomer.Result.Colour.ShouldEqual("Super White II");
        }

        [Observation]
        public void rgt_vin_transformer_result_vin_should_be_valid_test()
        {
            _transfomer.Result.Vin.ShouldEqual("SB1KV58E40F039277");
        }


        [Observation]
        public void rgt_vin_transformer_result_quarter_should_be_valid_test()
        {
            _transfomer.Result.Quarter.ShouldEqual(3);
        }


        [Observation]
        public void rgt_vin_transformer_result_car_full_name_should_be_valid_test()
        {
            _transfomer.Result.CarFullname.ShouldEqual("TOYOTA Auris 1.6 RT 5-dr");
        }

    }
}
