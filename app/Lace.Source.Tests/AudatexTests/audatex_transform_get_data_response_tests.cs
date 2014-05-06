using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.Transform;
using Lace.Source.Tests.Data.Audatex;
using Xunit.Extensions;

namespace Lace.Source.Tests.AudatexTests
{
    public class audatex_transform_get_data_response_tests : Specification
    {
        private readonly GetDataResult _audatexWebServiceResponse;
        private TransformAudatexWebResponse _transformer;
        private readonly ILaceResponse _response;
        private readonly ILaceRequest _request;

        public audatex_transform_get_data_response_tests()
        {
            _response = MockAudatexWebResponseData.GetLaceResponseToUserInAudatexRequest();
            _request = MockAudatexLicensePlateNumberRequestData.GetLicensePlateNumberRequestForAudatex();
            _audatexWebServiceResponse = MockAudatexWebResponseData.GetAudatexWebServiceResultWithHyundaiHistoryResponseInformation();
        }


        public override void Observe()
        {
            _transformer = new TransformAudatexWebResponse(_audatexWebServiceResponse, _response, _request);
            _transformer.Transform();
        }

        [Observation]
        public void audatex_transformer_continue_with_transformation_must_be_true_test()
        {
            _transformer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void audatex_transformer_result_should_not_be_null_test()
        {
            _transformer.Result.ShouldNotBeNull();
        }

        [Observation]
        public void audatex_transformer_result_must_have_valid_accident_claims_test()
        {
            _transformer.Result.AccidentClaims.ShouldNotBeNull();
        }

        [Observation]
        public void audatex_transformer_result_must_have_an_accident_claims_test()
        {
            _transformer.Result.AccidentClaims.Count.ShouldEqual(1);
        }

        [Observation]
        public void audatex_transformer_result_accident_claim_must_have_valid_registration_no_test()
        {
            _transformer.Result.AccidentClaims[0].Registration.ShouldEqual("BB30DPGP");
        }

        [Observation]
        public void audatex_transfomer_result_accident_claim_must_have_valid_repair_cost_excl_vat_test()
        {
            _transformer.Result.AccidentClaims[0].RepairCostExVat.ShouldEqual(10000);
        }

        [Observation]
        public void audatex_transformer_result_accident_claim_must_have_valid_repair_cost_incl_vat_test()
        {
            _transformer.Result.AccidentClaims[0].RepairCostIncVat.ShouldEqual(14000);
        }


        [Observation]
        public void audatex_transformer_result_accident_claim_must_have_valid_vin_number_test()
        {
            _transformer.Result.AccidentClaims[0].Vin.ShouldEqual("MALAC51HLAM496530");
        }

        [Observation]
        public void audatex_transformer_result_accident_claim_must_have_quote_value_indicator_test()
        {
            _transformer.Result.AccidentClaims[0].QuoteValueIndicator.ShouldEqual("R 10 000,00 to R 50 000,00 !");
        }
    }
}
