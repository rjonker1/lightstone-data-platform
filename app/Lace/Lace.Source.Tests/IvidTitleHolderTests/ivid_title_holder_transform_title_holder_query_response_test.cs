using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.Transform;
using Lace.Source.Tests.Data.IvidTitleHolder;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTitleHolderTests
{
    public class ivid_title_holder_transform_title_holder_query_response_test : Specification
    {
        private readonly TitleholderQueryResponse _ividTitleHolderResponse;
        private TransformIvidTitleHolderResponse _transformer;

        public ivid_title_holder_transform_title_holder_query_response_test()
        {
            _ividTitleHolderResponse = MockIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicnseNumber();
        }
        

        public override void Observe()
        {
            _transformer = new TransformIvidTitleHolderResponse(_ividTitleHolderResponse);
            _transformer.Transform();
        }


        [Observation]
        public void ivid_title_holder_transformer_continue_with_transformation_must_be_true_test()
        {
            _transformer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_transformer_request_for_financial_invite_must_be_avail_test()
        {
            _transformer.Result.RequestFinancialInterestInvite.ShouldEqual("To request financial interest please click on the 'Request' button");
        }

        [Observation]
        public void ivid_title_holder_transformer_financial_interest_avail_should_be_true_test()
        {
            _transformer.Result.FinancialInterestAvailable.ShouldBeTrue();
        }

    }
}
