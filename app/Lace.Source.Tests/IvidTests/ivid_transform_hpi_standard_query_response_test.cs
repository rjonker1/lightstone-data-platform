using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.Transform;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTests
{
    public class ivid_transform_hpi_standard_query_response_test : Specification
    {
        private readonly HpiStandardQueryResponse _ividWebServiceResponse;
        private TransformIvidWebResponse _transfomer;

        public ivid_transform_hpi_standard_query_response_test()
        {
            _ividWebServiceResponse =
                Data.Ivid.MockIvidHpiStandardQueryResponseData.GetHpiStandardQueryResponseForLicenseNoXmc167Gp();
        }
        
        public override void Observe()
        {
            _transfomer = new TransformIvidWebResponse(_ividWebServiceResponse);
            _transfomer.Transform();
        }

        [Observation]
        public void ivid_transformer_continue_with_transformation_must_be_true_test()
        {
            _transfomer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void ivid_transformer_result_should_not_be_null_test()
        {
            _transfomer.Result.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_vin_number_test()
        {
            _transfomer.Result.Vin.ShouldEqual("SB1KV58E40F039277");
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_color_properties_test()
        {
            _transfomer.Result.ColourCode.ShouldEqual("3");
            _transfomer.Result.ColourDescription.ShouldEqual("White");
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_registration_test()
        {
            _transfomer.Result.Registration.ShouldEqual("CNC407L");
        }

        [Observation]
        public void ivid_transformer_result_shoudl_have_valid_license_number_test()
        {
            _transfomer.Result.License.ShouldEqual("XMC167GP");
        }

        [Observation]
        public void ivid_transformer_result_should_have_valid_engine_number_test()
        {
            _transfomer.Result.Engine.ShouldEqual("1ZRU041295");
        }
    }
}
