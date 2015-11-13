using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Packages;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_ivid_response : Specification
    {
        private readonly HpiStandardQueryResponse _ividWebServiceResponse;
        private TransformIvidResponse _transfomer;

        public when_transforming_ivid_response()
        {
            _ividWebServiceResponse = new SourceResponseBuilder().ForIvid();
        }


        public override void Observe()
        {
            _transfomer = new TransformIvidResponse(_ividWebServiceResponse);
            _transfomer.Transform();
        }

        [Observation]
        public void ivid_transformer_continue_with_transformation_must_be_true()
        {
            _transfomer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void ivid_transformer_result_should_not_be_null()
        {
            _transfomer.Result.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_vin_number()
        {
            _transfomer.Result.Vin.ShouldEqual("SB1KV58E40F039277");
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_color_properties()
        {
            _transfomer.Result.ColourCode.ShouldEqual("3");
            _transfomer.Result.ColourDescription.ShouldEqual("White");
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_registration()
        {
            _transfomer.Result.Registration.ShouldEqual("CNC407L");
        }

        [Observation]
        public void ivid_transformer_result_shoudl_have_valid_license_number()
        {
            _transfomer.Result.License.ShouldEqual("XMC167GP");
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_engine_number()
        {
            _transfomer.Result.Engine.ShouldEqual("1ZRU041295");
        }
    }
}
