﻿using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.Transform;
using Lace.Source.RgtVin.Transform;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_rgt_vin_response : Specification
    {
        private readonly System.Data.DataSet _rgtVinWebResponse;
        private TransformRgtVinResponse _transfomer;

        public when_transforming_rgt_vin_response()
        {
            _rgtVinWebResponse = new SourceResponseBuilder().ForRgtVin();
        }


        public override void Observe()
        {
            _transfomer = new TransformRgtVinResponse(_rgtVinWebResponse);
            _transfomer.Transform();
        }

        [Observation]
        public void rgt_vin_transformer_continue_with_transformation_must_be_true()
        {
            _transfomer.Continue.ShouldBeTrue();
        }


        [Observation]
        public void rgt_vin_transformer_result_should_not_be_null()
        {
            _transfomer.Result.ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_transformer_result_color_should_be_valid()
        {
            _transfomer.Result.Colour.ShouldEqual("Super White II");
        }

        [Observation]
        public void rgt_vin_transformer_result_vin_should_be_valid()
        {
            _transfomer.Result.Vin.ShouldEqual("SB1KV58E40F039277");
        }


        [Observation]
        public void rgt_vin_transformer_result_quarter_should_be_valid()
        {
            _transfomer.Result.Quarter.ShouldEqual(3);
        }


        [Observation]
        public void rgt_vin_transformer_result_car_full_name_should_be_valid()
        {
            _transfomer.Result.CarFullname.ShouldEqual("TOYOTA Auris 1.6 RT 5-dr");
        }
    }
}